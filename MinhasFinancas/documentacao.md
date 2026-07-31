# Documentação do Projeto: Minhas Finanças

## 1. Descrição Inicial
O projeto "Minhas Finanças" visa ser um gerenciador financeiro completo capaz de registrar receitas, despesas, gerenciar cartões de crédito e visualizar relatórios detalhados.

Esta etapa consistiu na fundação e estruturação da arquitetura base.

## 2. Arquitetura da Solução
A arquitetura foi definida com uma separação limpa entre backend corporativo e frontend reativo:
- **Backend:** Node.js com Express para lidar com requisições HTTP e estruturar uma API RESTful.
- **Banco de Dados:** SQL Server (`mssql`), mantendo alta performance e integridade de dados através de queries transacionais nativas em vez de ORMs.
- **Frontend:** React com Vite para garantir builds ultrarrápidos e uma base componentizável sólida. Tecnologias base foram aplicadas (HTML/CSS/JS puros primeiramente).

## 3. Diretórios e Arquivos Mapeados (Estado Atual)
- `/backend`: Contém a API em Node.js.
  - `src/server.js`: Entrada da aplicação.
  - `src/config/database.js`: Pooling de conexões ao SQL Server.
  - `src/routes/healthRoutes.js`: Rota de teste.
  - `.env` (Pendente criação local pelo dev devido a bloqueios).
- `/frontend`: Aplicação React/Vite.
  - `src/App.jsx`: Componente principal, limpo para implementações subsequentes.
  - `src/index.css`: Estilização basilar e variáveis CSS.
- `/database`:
  - `01_create_database.sql`: Script T-SQL para iniciar o banco local.

## 4. Instruções de Uso
1. **Backend:** Em `/backend`, execute `npm install` e depois `node src/server.js` (ou instale `nodemon` depois). 
   - Teste a rota em `http://localhost:3000/api/health`.
2. **Frontend:** Em `/frontend`, execute `npm run dev`.
   - Acesse `http://localhost:5173`.

## 5. Rollback
O projeto foi apenas inicializado. Para rollback, basta excluir as pastas `/frontend`, `/backend`, `/database`. Nenhuma funcionalidade anterior foi perdida pois o diretório encontrava-se vazio.
