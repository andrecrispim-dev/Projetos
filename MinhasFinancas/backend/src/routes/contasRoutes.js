const express = require('express');
const router = express.Router();
const contasController = require('../controllers/contasController');

// Define as rotas que ficarão por trás de /api/contas
router.get('/', contasController.getAll);
router.post('/', contasController.create);

module.exports = router;
