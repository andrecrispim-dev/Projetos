# Planilha Financeira — Contas a Pagar e Receber

Sistema web para controlar **contas a pagar** e **contas a receber**: vencimentos, status de pagamento, categorias, relatórios e backup.

O aplicativo em uso está em **`controle-financeiro/`** (API Node.js + frontend React + SQLite).

> Os arquivos na raiz (`index.html`, `script.js`, `styles.css`, `exemplo-uso.md`) são um **protótipo antigo** em HTML/JS com `localStorage`. Não fazem parte do fluxo atual.

Documentação detalhada: [`controle-financeiro/README.md`](controle-financeiro/README.md)

---

## O que o sistema faz hoje

- **Dashboard** — resumo do mês (a pagar/receber pendente, já pago/recebido, saldo projetado), alertas de vencidas, vencendo hoje e próximos 7 dias
- **Lançamentos** — CRUD de contas a pagar/receber, com filtros, paginação e status (`PENDENTE`, `CONCLUIDO`, `CANCELADO`)
- **Ações de status** — concluir (pagar/receber), reabrir e cancelar
- **Recorrência na criação** — gera várias parcelas (semanal, quinzenal, mensal ou anual) a partir da quantidade informada
- **Categorias** — CRUD com tipo Pagar, Receber ou Ambos
- **Relatórios** — resumo do período, por categoria e por mês (gráficos)
- **Exportação CSV** dos lançamentos
- **Backup** do banco SQLite (criar, listar e baixar); restauração ainda é manual
- **Tema** claro/escuro no navegador

Não há login/usuários: pensado para uso local (ou rede privada). Em VPS pública, proteja com proxy/auth externo.

---

## Como rodar (Windows)

Pré-requisito: **Node.js 22+**.

```bat
cd controle-financeiro\scripts
controle.bat
```

Isso sobe backend e frontend. Com o script em execução, `Ctrl+C` pergunta se deseja **parar**, **reiniciar** ou **continuar**.

Atalhos:

```bat
controle.bat parar
controle.bat reiniciar
```

URLs locais (configuração atual):

| Serviço  | URL |
|----------|-----|
| Frontend | http://localhost:5173 |
| Backend  | http://localhost:3001 |
| Health   | http://localhost:3001/api/health |

Na primeira vez, copie os `.env.example` se ainda não existirem (o `controle.bat` também faz isso):

- `controle-financeiro/backend/.env` → `PORT=3001`
- `controle-financeiro/frontend/.env` → `VITE_API_URL=http://localhost:3001/api`

Dados de demonstração (opcional):

```bash
cd controle-financeiro/backend
npm run seed
```

---

## Stack

| Camada   | Tecnologia |
|----------|------------|
| Frontend | React, Vite, React Router, Recharts |
| Backend  | Node.js, Express, Zod, Helmet, CORS, rate limit |
| Banco    | SQLite (`backend/data/financeiro.sqlite`) |
| Deploy   | Docker Compose (porta 3000 no container; ver README interno) |

---

## Estrutura do repositório

```text
Planilha Financeira/
├── controle-financeiro/     ← sistema atual
│   ├── backend/
│   ├── frontend/
│   ├── scripts/controle.bat
│   └── README.md
├── index.html / script.js   ← legado (não usar)
└── README.md                ← este arquivo
```
