-- Script de Criação Inicial do Banco de Dados
-- Projeto: Minhas Finanças
-- Banco: SQL Server (Local)

-- Verifica e cria o banco se não existir
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MinhasFinancasDB')
BEGIN
    CREATE DATABASE MinhasFinancasDB;
    PRINT '✅ Banco de dados MinhasFinancasDB criado com sucesso.';
END
ELSE
BEGIN
    PRINT '⚠️ Banco de dados MinhasFinancasDB já existe.';
END
GO

USE MinhasFinancasDB;
GO

-- Crie tabelas iniciais a seguir caso não existam
-- TABELAS PRINCIPAIS: USUÁRIOS, CATEGORIAS, CONTAS, TRANSACOES
