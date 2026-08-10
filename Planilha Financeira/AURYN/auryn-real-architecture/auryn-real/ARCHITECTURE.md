# Arquitetura AURYN

```text
[iOS / Android]
      |
   HTTPS/TLS
      v
[API Fastify]
  |    |    \
  |    |     +--> Redis (cache / jobs)
  |    +--------> Audit logs
  v
[PostgreSQL]
      |
[Open Finance Provider]
      |
[Banks / Institutions]
```

## Domínios
1. Identity: cadastro, sessão, MFA/passkeys.
2. Wealth: patrimônio, contas, investimentos, imóveis e outros ativos.
3. Cashflow: receitas, despesas, cartões e recorrências.
4. Goals: metas e planejamento.
5. Insights: indicadores e relatórios.
6. Integrations: Open Finance e custodiante/provedores de investimentos.
7. Admin: suporte, consentimentos, auditoria e gestão de acesso.

## Segurança
- Nunca guardar senha em texto puro.
- Refresh token somente como hash no banco e rotação a cada uso.
- Access token curto.
- Ownership check em toda query por usuário.
- HTTPS obrigatório em produção.
- Secrets em secret manager/KMS, não no código.
- Logs sem dados financeiros sensíveis.
- MFA/passkey antes do lançamento comercial.
- Criptografia em repouso e em trânsito.
- Rate limiting, proteção contra brute force e WAF.
- Auditoria imutável para ações críticas.

## Dados sensíveis
Para Open Finance, evitar guardar credenciais bancárias. O consentimento e a conexão devem ser gerenciados por um provedor adequado; tokens de integração devem ser criptografados e segregados.

## Produção
Ambientes separados (dev/staging/prod), CI/CD, migrations controladas, backups automáticos, recuperação de desastre, monitoramento, alertas, Sentry/OpenTelemetry, pentest e revisão LGPD/regulatória.
