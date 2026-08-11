# AURYN — Análise de Comercialização (Web, Android, iOS)

> Versão em documento deste relatório. Existe também uma versão interativa (scorecard, tabelas e roadmap navegável) publicada como Artifact na mesma conversa em que esta análise foi produzida.
>
> Referências: o app atual vive em [`controle-financeiro/`](controle-financeiro/); os dois protótipos citados abaixo vivem em [`AURYN/`](AURYN/).

Hoje o AURYN é uma ferramenta pessoal sólida — Express, SQLite, sem login, um usuário só (o próprio [README.md](README.md) documenta isso: *"Não há login/usuários: pensado para uso local"*). Comercializar como app Web, Android e iOS é uma mudança de categoria, não um ajuste. Esta análise parte dos dois protótipos que já existem em `AURYN/` e aponta, item a item, o caminho até lá.

## 1. Diagnóstico do estado atual

| Domínio | Situação hoje | Por que importa |
|---|---|---|
| **Autenticação** | Não existe login. `backend/src/app.js` não tem nenhum middleware de sessão ou token — qualquer requisição à API tem acesso total. | Bloqueador nº 1. Um produto comercial não pode compartilhar um único banco entre todo mundo. |
| **Banco de dados** | Um arquivo `.sqlite` local (`better-sqlite3`), sem conceito de usuário dono dos dados. | Funciona perfeitamente para 1 pessoa. Não sustenta múltiplos usuários simultâneos nem isolamento de dados. |
| **Web** | React + Vite, 12 módulos funcionais (Dashboard, Lançamentos, Contas, Faturas, Metas, Investimentos, Plantões/Agenda, Relatórios...), com testes e um design system consistente. | Maior ativo reaproveitável do projeto — a maior parte da UI não precisa ser refeita, só reconectada a uma API com autenticação. |
| **Mobile** | Nenhum app real. Existe uma única tela de protótipo (login + dashboard) em Expo dentro de `AURYN/auryn-real-architecture`. | Android e iOS partem essencialmente do zero — a decisão de caminho (seção 3) define o prazo. |
| **Cobrança** | Não existe nenhuma menção a plano, preço ou assinatura em nenhum dos dois protótipos. | Sem isso não há como cobrar — é uma decisão de produto, não só técnica (seção 6). |
| **LGPD / conformidade** | Inexistente. | Necessário antes de qualquer lançamento com dados financeiros reais de terceiros. |
| **Infra / CI-CD** | Manual — sem pipeline, sem ambientes separados, backup por download de arquivo `.sqlite`. | Precisa existir antes de operar um serviço pago. |

## 2. O que já existe para reaproveitar

A pasta `AURYN/` guarda dois exercícios de naturezas bem diferentes:

**`AURYN_finance_app_MVP`** — um único `index.html` estático, sem backend, dados falsos em `localStorage`. Mostra a direção visual (rail lateral + barra inferior no mobile) mas não é código de produção. Serviu de referência para a proposta de navegação (item 8).

**`auryn-real-architecture/auryn-real`** — monorepo com `apps/api` (Fastify + TypeScript + Prisma + PostgreSQL) e `apps/mobile` (Expo + React Native). Já implementa registro, login, JWT com refresh rotativo (hash em banco, rotação em uso único), e endpoints de `transactions`, `investments` e `goals` — todos filtrados por `userId`. É uma base de arquitetura genuinamente utilizável, não apenas um mockup.

O que ainda falta mesmo no protótipo mais avançado:
- `packages/shared` existe só como nome — nenhum tipo ou validação é compartilhado entre API e mobile ainda.
- Não há app **web** nesse monorepo — só API e mobile.
- Sem CI, sem ambientes separados de homologação/produção, sem pipeline de deploy.
- O próprio `ARCHITECTURE.md` do protótipo lista o que falta antes de um lançamento comercial: MFA/passkeys, gestão de segredos (KMS), rate limiting distribuído, trilha de auditoria imutável, backups, LGPD.

## 3. Estratégia por plataforma

**Web** — evoluir o React atual, não reescrever. O trabalho real é trocar a base da API (de Express/SQLite sem auth para a API com autenticação já esboçada no protótipo), adicionar telas de login/cadastro/perfil, e passar cada tela de "os dados" para "os dados deste usuário".

**Android e iOS** — duas rotas possíveis, com uma base de código comum às duas plataformas em qualquer uma delas:

| Caminho | Como | A favor | Contra |
|---|---|---|---|
| **A — Capacitor** (recomendado como primeiro passo) | Empacotar o web app atual | Reaproveita ~100% do React/CSS já pronto; publica nas duas lojas rapidamente; PWA/manifest já preparados na Fase A deste projeto | Não é "nativo" de verdade — push exige plugin extra, sem gestos nativos |
| **B — Expo / React Native nativo** | Evoluir o protótipo mobile já iniciado | Melhor sensação nativa, biometria, push e deep-linking de verdade | Exige reconstruir toda a interface em React Native — cronograma bem mais longo |

Recomendação: **A primeiro**, para chegar às lojas rápido e validar demanda; migrar as telas mais usadas para **B** depois, se a tração justificar o investimento.

## 4. Domínios que faltam por completo

- **Cobrança e assinatura** — planos, trial, upgrade/downgrade (ex.: Stripe). Nenhum provedor integrado hoje.
- **Multi-tenancy real** — o protótipo é 1 usuário por conta; não existe ainda o conceito de família/equipe compartilhando um plano.
- **LGPD e conformidade** — termos de uso, política de privacidade, exportação e exclusão de dados sob pedido.
- **Open Finance** — sincronia automática com bancos e corretoras (conecta com o pedido de importação/integração do módulo Investimentos); exige homologação com provedor autorizado, não é uma integração trivial.
- **Notificações** — push mobile e e-mail para vencimentos de contas e metas próximas do prazo.
- **Observabilidade e CI/CD** — logs centralizados, testes em pipeline, ambientes de homologação e produção separados.
- **Suporte e admin** — painel para atender usuários, ver métricas de uso, cancelar contas.

## 5. Roadmap priorizado

Ordenado por dependência, não por data — cada fase é pré-requisito da seguinte.

**Fase 0 — Fundação segura.** Pré-requisito de tudo.
- Autenticação real (registro, login, sessão) sobre o esqueleto Fastify/Prisma já prototipado.
- Migrar de SQLite para PostgreSQL com dados isolados por usuário.

**Fase 1 — Monetização mínima.** O produto passa a poder cobrar e operar dentro da lei.
- Integração de cobrança (ex.: Stripe), planos e tela de upgrade.
- LGPD básico: termos, política de privacidade, exportar/excluir dados.

**Fase 2 — Mobile MVP.** Chegada às lojas com o menor esforço possível.
- Empacotar o web app com Capacitor, publicar em Google Play e App Store.
- PWA instalável como alternativa leve.

**Fase 3 — Nativo e integrações.** Só compensa depois de validar demanda nas fases anteriores.
- Migrar telas de maior uso para Expo/React Native nativo.
- Open Finance — primeiro bancos, depois corretoras.
- Notificações push.

## 6. Pontos a mudar e melhorar

- **Estrutura** — sair de "1 processo Express + 1 arquivo SQLite" para "API com usuários + PostgreSQL" antes de qualquer coisa comercial. É o único item que bloqueia todo o resto.
- **Segurança** — hoje não existe login nenhum. Se este endereço já é acessível fora da rede local, é o risco mais urgente do projeto, independente de virar produto comercial ou não.
- **Banco de dados** — decidir se o SQLite continua existindo como versão "pessoal/self-host" separada, ou se todo mundo migra para a versão com PostgreSQL. São dois produtos diferentes, não uma migração única.
- **Mobile** — escolher Capacitor vs. Expo nativo cedo; a escolha muda o cronograma inteiro das fases 2 e 3.
- **Modelo de negócio** — nenhum dos dois protótipos define preço, plano ou moeda de cobrança. É uma decisão do usuário, não técnica, e trava a Fase 1 até ser tomada.
- **Nicho** — o AURYN mistura controle financeiro geral com agenda de plantões médicos, uma combinação bem específica. Vale decidir se o produto comercial abraça esse nicho (vender para profissionais de plantão) ou generaliza e transforma Plantões em módulo opcional.

## 7. Decisões em aberto

1. **Nicho ou generalista?** Vender para o público amplo de controle financeiro, ou assumir o nicho de profissionais com plantão/agenda irregular como diferencial de posicionamento? Muda copy, prioridade de features e até o nome dos planos.
2. **Fundação primeiro, ou mobile primeiro?** A Fase 0 (auth + PostgreSQL) não é visível para ninguém de fora — é infraestrutura. Se a prioridade é mostrar algo tangível rápido, dá para adiantar um protótipo mobile em paralelo, sabendo que ele ainda vai depender da Fase 0 para sair do papel.
