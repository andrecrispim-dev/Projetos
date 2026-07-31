-- Criação da Tabela de Contas com base no esqueleto arquitetural premium
USE MinhasFinancasDB;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Contas')
BEGIN
    CREATE TABLE Contas (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Categoria_Conta NVARCHAR(50) NOT NULL, -- Ex: Conta Corrente, Poupança, Carteira Física, Cartão de Crédito
        Instituicao NVARCHAR(100) NULL,        -- Ex: Nubank, Itau, etc (Permite null para carteira fisica)
        Icone NVARCHAR(50) NULL,             -- Referência ao nome do Icone do lucide-react (Ex: Landmark, Wallet)
        Saldo_Inicial DECIMAL(18,2) NOT NULL DEFAULT 0.00,
        Saldo_Atual DECIMAL(18,2) NOT NULL DEFAULT 0.00,
        Cor_Destaque NVARCHAR(20) NULL,      -- Ex: #8b5cf6 para Nubank
        Ativo BIT NOT NULL DEFAULT 1,
        Data_Criacao DATETIME NOT NULL DEFAULT GETDATE()
    );
    PRINT '✅ Tabela [Contas] criada com sucesso.';
END
ELSE
BEGIN
    PRINT '⚠️ A tabela [Contas] já existe.';
END
GO
