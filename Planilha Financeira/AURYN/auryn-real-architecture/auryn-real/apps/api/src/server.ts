import Fastify from 'fastify';
import cors from '@fastify/cors';
import helmet from '@fastify/helmet';
import jwt from '@fastify/jwt';
import bcrypt from 'bcryptjs';
import { PrismaClient } from '@prisma/client';
import { randomBytes, createHash } from 'node:crypto';
import { z } from 'zod';
import 'dotenv/config';

const transactionTypes = ['INCOME', 'EXPENSE'] as const;
const investmentClasses = ['FIXED_INCOME', 'EQUITY', 'FUND', 'REAL_ESTATE', 'EXTERIOR', 'OTHER'] as const;

const prisma = new PrismaClient();
const app = Fastify({ logger: true });

await app.register(helmet);
await app.register(cors, { origin: process.env.CORS_ORIGIN || false });
await app.register(jwt, { secret: process.env.JWT_SECRET || 'dev-only-change-me' });

const auth = async (req: any, reply: any) => {
  try {
    await req.jwtVerify();
  } catch {
    return reply.code(401).send({ error: 'Não autenticado' });
  }
};

const uid = (req: any) => req.user.sub as string;
const hash = (value: string) => createHash('sha256').update(value).digest('hex');
const issueRefresh = () => randomBytes(48).toString('base64url');

app.get('/health', async () => ({ ok: true, service: 'auryn-api' }));

app.post('/auth/register', async (req, reply) => {
  const body = z.object({
    name: z.string().min(2).max(120),
    email: z.string().email(),
    password: z.string().min(10).max(128),
  }).parse(req.body);

  const email = body.email.toLowerCase();
  const exists = await prisma.user.findUnique({ where: { email } });
  if (exists) return reply.code(409).send({ error: 'E-mail já cadastrado' });

  const user = await prisma.user.create({
    data: {
      name: body.name,
      email,
      passwordHash: await bcrypt.hash(body.password, 12),
    },
  });
  const accessToken = app.jwt.sign({ sub: user.id, email: user.email }, { expiresIn: '15m' });
  const refreshToken = issueRefresh();

  await prisma.session.create({
    data: {
      userId: user.id,
      refreshHash: hash(refreshToken),
      expiresAt: new Date(Date.now() + 30 * 86400000),
    },
  });

  return reply.code(201).send({
    user: { id: user.id, name: user.name, email: user.email },
    accessToken,
    refreshToken,
  });
});

app.post('/auth/login', async (req, reply) => {
  const body = z.object({
    email: z.string().email(),
    password: z.string(),
  }).parse(req.body);

  const user = await prisma.user.findUnique({ where: { email: body.email.toLowerCase() } });
  if (!user || !(await bcrypt.compare(body.password, user.passwordHash))) {
    return reply.code(401).send({ error: 'Credenciais inválidas' });
  }

  const accessToken = app.jwt.sign({ sub: user.id, email: user.email }, { expiresIn: '15m' });
  const refreshToken = issueRefresh();

  await prisma.session.create({
    data: {
      userId: user.id,
      refreshHash: hash(refreshToken),
      expiresAt: new Date(Date.now() + 30 * 86400000),
    },
  });
  await prisma.auditLog.create({ data: { userId: user.id, action: 'LOGIN', entity: 'Session', ip: req.ip } });

  return {
    user: { id: user.id, name: user.name, email: user.email },
    accessToken,
    refreshToken,
  };
});

app.post('/auth/refresh', async (req, reply) => {
  const { refreshToken } = z.object({ refreshToken: z.string().min(20) }).parse(req.body);
  const session = await prisma.session.findUnique({
    where: { refreshHash: hash(refreshToken) },
    include: { user: true },
  });

  if (!session || session.expiresAt < new Date()) {
    return reply.code(401).send({ error: 'Refresh token inválido' });
  }

  const nextRefreshToken = issueRefresh();
  await prisma.$transaction([
    prisma.session.delete({ where: { id: session.id } }),
    prisma.session.create({
      data: {
        userId: session.userId,
        refreshHash: hash(nextRefreshToken),
        expiresAt: new Date(Date.now() + 30 * 86400000),
      },
    }),
  ]);

  return {
    accessToken: app.jwt.sign({ sub: session.user.id, email: session.user.email }, { expiresIn: '15m' }),
    refreshToken: nextRefreshToken,
  };
});

app.post('/auth/logout', { preHandler: auth }, async (req: any) => {
  await prisma.auditLog.create({ data: { userId: uid(req), action: 'LOGOUT', entity: 'Session', ip: req.ip } });
  return { ok: true };
});

app.get('/me', { preHandler: auth }, async (req: any) => (
  prisma.user.findUnique({
    where: { id: uid(req) },
    select: { id: true, name: true, email: true, createdAt: true },
  })
));

app.get('/dashboard', { preHandler: auth }, async (req: any) => {
  const userId = uid(req);
  const [transactions, investments, goals] = await Promise.all([
    prisma.transaction.findMany({ where: { userId }, orderBy: { occurredAt: 'desc' }, take: 100 }),
    prisma.investment.findMany({ where: { userId } }),
    prisma.goal.findMany({ where: { userId } }),
  ]);

  const income = transactions
    .filter((transaction: any) => transaction.type === 'INCOME')
    .reduce((sum: number, transaction: any) => sum + Number(transaction.amount), 0);
  const expense = transactions
    .filter((transaction: any) => transaction.type === 'EXPENSE')
    .reduce((sum: number, transaction: any) => sum + Number(transaction.amount), 0);
  const invested = investments.reduce((sum: number, investment: any) => sum + Number(investment.current), 0);

  return {
    summary: { income, expense, cash: income - expense, invested, netWorth: income - expense + invested },
    transactions: transactions.slice(0, 20),
    investments,
    goals,
  };
});

app.get('/transactions', { preHandler: auth }, async (req: any) => (
  prisma.transaction.findMany({ where: { userId: uid(req) }, orderBy: { occurredAt: 'desc' } })
));

app.post('/transactions', { preHandler: auth }, async (req: any) => {
  const body = z.object({
    description: z.string().min(1).max(160),
    category: z.string().min(1).max(80),
    type: z.enum(transactionTypes),
    amount: z.number().positive(),
    occurredAt: z.coerce.date(),
    accountId: z.string().optional(),
  }).parse(req.body);

  return prisma.transaction.create({ data: { ...body, userId: uid(req) } });
});

app.delete('/transactions/:id', { preHandler: auth }, async (req: any, reply) => {
  const { id } = req.params as { id: string };
  const result = await prisma.transaction.deleteMany({ where: { id, userId: uid(req) } });
  return result.count ? { ok: true } : reply.code(404).send({ error: 'Não encontrado' });
});

app.get('/investments', { preHandler: auth }, async (req: any) => (
  prisma.investment.findMany({ where: { userId: uid(req) } })
));

app.post('/investments', { preHandler: auth }, async (req: any) => {
  const body = z.object({
    name: z.string().min(1).max(160),
    class: z.enum(investmentClasses),
    invested: z.number().nonnegative(),
    current: z.number().nonnegative(),
    currency: z.string().length(3).default('BRL'),
  }).parse(req.body);

  return prisma.investment.create({ data: { ...body, userId: uid(req) } });
});

app.get('/goals', { preHandler: auth }, async (req: any) => (
  prisma.goal.findMany({ where: { userId: uid(req) }, orderBy: { createdAt: 'desc' } })
));

app.post('/goals', { preHandler: auth }, async (req: any) => {
  const body = z.object({
    name: z.string().min(1).max(160),
    target: z.number().positive(),
    current: z.number().nonnegative().default(0),
    deadline: z.coerce.date().optional(),
  }).parse(req.body);

  return prisma.goal.create({ data: { ...body, userId: uid(req) } });
});

const port = Number(process.env.PORT || 4000);
app.listen({ port, host: '0.0.0.0' }).catch((error) => {
  app.log.error(error);
  process.exit(1);
});
