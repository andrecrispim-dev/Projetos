const { getConnection, sql } = require('../config/database');

const contasController = {
    
    // Obter todas as contas do usuário
    getAll: async (req, res) => {
        try {
            const pool = await getConnection();
            // A consulta abaixo já traz as contas mais novas primeiro
            const result = await pool.request().query('SELECT * FROM Contas ORDER BY Data_Criacao DESC');
            return res.status(200).json(result.recordset);
        } catch (error) {
            console.error('❌ Erro no getAll contas:', error);
            return res.status(500).json({ error: 'Falha ao buscar as contas bancárias no banco de dados.', details: error.message });
        }
    },

    // Criar nova conta
    create: async (req, res) => {
        const { nome, categoria_conta, instituicao, icone, saldo_inicial, cor_destaque } = req.body;

        // Validação mínima imposta pelo banco SQL (campos NOT NULL)
        if (!nome || !categoria_conta) {
            return res.status(400).json({ error: "O Nome e a Categoria_Conta são propriedades obrigatórias!" });
        }

        try {
            const pool = await getConnection();
            
            // Tratamento das queries parametrizadas (Evita SQL Injection nativamente)
            // O OUTPUT serve para retornar a linha inserida logo após inseri-la
            const query = `
                INSERT INTO Contas 
                (Nome, Categoria_Conta, Instituicao, Icone, Saldo_Inicial, Saldo_Atual, Cor_Destaque)
                OUTPUT INSERTED.*
                VALUES 
                (@Nome, @Categoria_Conta, @Instituicao, @Icone, @Saldo_Inicial, @Saldo_Atual, @Cor_Destaque)
            `;

            const saldo = saldo_inicial || 0; // Se não for passado, saldo é zero
            const cor = cor_destaque || '#10b981'; // Cor primária Emerald por default
            const icn = icone || 'Wallet'; // Icone carteira lucide padrão

            const result = await pool.request()
                .input('Nome', sql.NVarChar, nome)
                .input('Categoria_Conta', sql.NVarChar, categoria_conta)
                .input('Instituicao', sql.NVarChar, instituicao || null)
                .input('Icone', sql.NVarChar, icn)
                .input('Saldo_Inicial', sql.Decimal(18, 2), saldo)
                .input('Saldo_Atual', sql.Decimal(18, 2), saldo) 
                .input('Cor_Destaque', sql.NVarChar, cor)
                .query(query);

            return res.status(201).json(result.recordset[0]);
        } catch (error) {
            console.error('❌ Erro no create conta:', error);
            return res.status(500).json({ error: 'Erro inesperado ao cadastrar a nova conta.', details: error.message });
        }
    }
};

module.exports = contasController;
