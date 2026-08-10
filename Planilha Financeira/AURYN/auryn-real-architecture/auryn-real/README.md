# AURYN - arquitetura real

Monorepo inicial para transformar o MVP visual em um aplicativo financeiro real.

## Stack

- API: Node.js + Fastify + TypeScript
- Banco: PostgreSQL + Prisma
- Cache/filas: Redis, preparado no Docker Compose
- Mobile: Expo + React Native + TypeScript
- Auth: access token curto + refresh token rotativo armazenado com hash
- Validação: Zod

## Pré-requisitos

- Node.js e npm
- Docker Desktop, para subir PostgreSQL e Redis localmente
- Expo Go no celular, Android Emulator, iOS Simulator ou build nativo

## API

```powershell
cd "D:\Projetos\Planilha Financeira\AURYN\auryn-real-architecture\auryn-real"
docker compose -f infra\docker-compose.yml up -d postgres redis
cd apps\api
copy .env.example .env
npm install
npx prisma migrate dev --name init
npm run dev
```

Health check:

```text
http://127.0.0.1:4000/health
```

## Mobile

Em emulador Android, o app usa `http://10.0.2.2:4000` por padrão.
Em iOS Simulator ou web, usa `http://localhost:4000`.
Em celular físico com Expo Go, copie `.env.example` para `.env` e troque `SEU_IP_LOCAL` pelo IP do computador na rede.

```powershell
cd "D:\Projetos\Planilha Financeira\AURYN\auryn-real-architecture\auryn-real\apps\mobile"
copy .env.example .env
npm install
npx expo start
```

Exemplo de `.env` para celular físico:

```env
EXPO_PUBLIC_API_URL="http://192.168.0.10:4000"
```

## Estado atual

- Cadastro, login, refresh e logout na API
- Dashboard autenticado
- Transações
- Investimentos
- Metas
- Prisma schema com ownership por usuário
- App mobile com tela de login/cadastro e dashboard básico

## Antes de produção

Ainda faltam MFA/passkeys, gestão de segredos, rate limiting distribuído, observabilidade, backups, CI/CD, LGPD/DPIA, política de retenção, KMS, Open Finance via provedor autorizado, antifraude, revisão jurídica/regulatória e ambientes separados.
