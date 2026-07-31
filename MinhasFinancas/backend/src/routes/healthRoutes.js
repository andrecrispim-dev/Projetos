const express = require('express');
const router = express.Router();
const { getConnection } = require('../config/database');

router.get('/health', async (req, res) => {
    try {
        // Testa a conexão do banco também
        const pool = await getConnection();
        await pool.request().query('SELECT 1 as Status');
        
        return res.status(200).json({ 
            api: '✅ Online', 
            database: '✅ Conectado ao SQL Server', 
            timestamp: new Date() 
        });
    } catch (error) {
        return res.status(500).json({ 
            api: '✅ Online', 
            database: '❌ Erro de conexão', 
            error: error.message 
        });
    }
});

module.exports = router;
