const express = require('express');
const cors = require('cors');
require('dotenv').config();

const healthRoutes = require('./routes/healthRoutes');
const contasRoutes = require('./routes/contasRoutes');

const app = express();
const PORT = process.env.PORT || 3000;

// Middlewares Globais
app.use(cors());
app.use(express.json());

// Registro das Rotas
app.use('/api', healthRoutes);
app.use('/api/contas', contasRoutes);

// Inicialização do Servidor
app.listen(PORT, () => {
    console.log(`=================================`);
    console.log(`🚀 Servidor rodando na porta ${PORT}`);
    console.log(`📍 Health Check: http://localhost:${PORT}/api/health`);
    console.log(`=================================`);
});
