# 🧠 Decision Log
*Registro de Decisões Técnicas das Iterações do Sistema "Minhas Finanças"*

---

## [31/03/2026] - Arquitetura de Inicialização

**Problema:**
Precisávamos arquitetar o setup fundamental do projeto, definindo as tecnologias exatas e suas relações para organizar a base de um sistema reativo (React), comunicando com a lógica de negócio (Node) salvando num banco complexo (SQL Server).

**Decisão Tomada:**
Opção 2 (Queries mais puras com `mssql`). O frontend será inicializado usando Vite ao invés de Create React App por ser muito mais leve e rápido.

**Justificativa:** 
Permite que nas próximas etapas os relatórios não sofram com os problemas do N+1, além da performance superior.

---

## [31/03/2026] - Layout Visual Base (Frontend)

**Problema:**
Definir a casca da User Interface da aplicação. 

**Decisão Tomada:**
Dark Mode Nativo Premium com `lucide-react`.

**Justificativa:** 
A estética premium atende o requisito principal com CSS puro.

---

## [31/03/2026] - Módulo de Contas Bancárias

**Problema:**
Estruturar o primeiro repositório real de dados (onde o saldo fica guardado) cobrindo front e backend.

**Opções Consideradas:**
1. Separar Bancos de Carteiras em tabelas diferentes.
2. Tabela Única `Contas` com a coluna `Categoria_Conta` agindo como discriminador.

**Decisão Tomada:**
Opção 2. Tabela Flat + SPA React (usando `react-router-dom`). Inserimos `Cor_Destaque` e `Icone` persistidos no banco.

**Justificativa:** 
Oferece liberdade total pra UI desenhar os *Cards* com as cores da Instituição sem depender de um banco imutável. SPA fornece zero refresh e velocidade.
