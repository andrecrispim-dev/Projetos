const sql = require('mssql/msnodesqlv8');
require('dotenv').config();

// Configurações do banco usando variáveis de ambiente ou os padrões definidos
const config = {
    server: process.env.DB_SERVER || 'localhost\\MSSQLSERVERDEV',
    database: process.env.DB_DATABASE || 'MinhasFinancasDB',
    user: process.env.DB_USER || 'sa',
    password: process.env.DB_PASSWORD, // Caso use Windows Authentication com usuário/senha padrão
    driver: 'msnodesqlv8',
    options: {
        encrypt: false, 
        trustServerCertificate: true, // Importante para rodar localmente sem certificados HTTPS no banco
        trustedConnection: false
    }
};

let globalPool;

async function getConnection() {
    try {
        if (!globalPool) {
            globalPool = await sql.connect(config);
            console.log('✅ Conectado ao SQL Server local com sucesso!');
        }
        return globalPool;
    } catch (err) {
        console.error('❌ Erro de conexão ao banco de dados:', err.message);
        throw err;
    }
}

module.exports = {
    sql,
    getConnection
};
