
// Dados globais
let entradas = JSON.parse(localStorage.getItem('entradas')) || [];
let saidas = JSON.parse(localStorage.getItem('saidas')) || [];
let cartoes = JSON.parse(localStorage.getItem('cartoes')) || [];

// Categorias por tipo de saída
const categoriasPorTipo = {
    'Despesa Fixa': ['Habitação', 'Transporte', 'Seguros', 'Educação', 'Saúde', 'Outros'],
    'Cartão de Crédito': ['Alimentação', 'Compras', 'Entretenimento', 'Saúde', 'Transporte', 'Educação', 'Outros'],
    'Despesa Esporádica': ['Alimentação', 'Transporte', 'Entretenimento', 'Presentes', 'Saúde', 'Educação', 'Outros']
};

// Funções de interface
function showTab(tabName, event) {
    // Remover classe active de todas as tabs
    document.querySelectorAll('.tab').forEach(tab => tab.classList.remove('active'));
    document.querySelectorAll('.tab-content').forEach(content => content.classList.remove('active'));

    // Adicionar classe active na tab clicada
    if (event && event.target) {
        event.target.classList.add('active');
    }
    document.getElementById(tabName).classList.add('active');

    // Atualizar conteúdo específico da tab
    if (tabName === 'resumo') {
        atualizarResumo();
    } else if (tabName === 'graficos') {
        setTimeout(() => atualizarGraficos(), 100); // Pequeno delay para garantir que o canvas esteja pronto
    } else if (tabName === 'cartoes') {
        atualizarCartoesGrid();
        atualizarResumoCartoes();
    }
}

function atualizarCategorias() {
    const tipo = document.getElementById('tipoSaida').value;
    const categoriaSelect = document.getElementById('categoriaSaida');
    const cartaoGroup = document.getElementById('cartaoGroup');

    categoriaSelect.innerHTML = '<option value="">Selecione uma categoria...</option>';

    if (tipo && categoriasPorTipo[tipo]) {
        categoriasPorTipo[tipo].forEach(categoria => {
            const option = document.createElement('option');
            option.value = categoria;
            option.textContent = categoria;
            categoriaSelect.appendChild(option);
        });
    }

    // Mostrar/ocultar campo de cartão
    if (tipo === 'Cartão de Crédito') {
        cartaoGroup.style.display = 'block';
        atualizarSelectCartoes();
    } else {
        cartaoGroup.style.display = 'none';
    }
}

// Funções de entrada
function adicionarEntrada() {
    const data = document.getElementById('dataEntrada').value;
    const tipo = document.getElementById('tipoEntrada').value;
    const descricao = document.getElementById('descricaoEntrada').value.trim();
    const valor = parseFloat(document.getElementById('valorEntrada').value);

    // Validações melhoradas
    if (!data) {
        alert('Por favor, selecione uma data!');
        return;
    }

    if (!tipo) {
        alert('Por favor, selecione um tipo de entrada!');
        return;
    }

    if (!valor || valor <= 0 || isNaN(valor)) {
        alert('Por favor, insira um valor válido maior que zero!');
        return;
    }

    const entrada = {
        id: Date.now() + Math.random(), // ID único mais robusto
        data,
        tipo,
        descricao,
        valor
    };

    entradas.push(entrada);
    salvarDados();
    atualizarTabelaEntradas();
    limparFormularioEntrada();

    // Feedback visual
    mostrarNotificacao('Entrada adicionada com sucesso!', 'success');
}

function limparFormularioEntrada() {
    document.getElementById('dataEntrada').value = '';
    document.getElementById('tipoEntrada').value = '';
    document.getElementById('descricaoEntrada').value = '';
    document.getElementById('valorEntrada').value = '';
}

function atualizarTabelaEntradas() {
    const tbody = document.querySelector('#tabelaEntradas tbody');
    if (!tbody) return;

    tbody.innerHTML = '';

    if (entradas.length === 0) {
        tbody.innerHTML = '<tr><td colspan="5" style="text-align: center; color: #6c757d;">Nenhuma entrada registrada</td></tr>';
        return;
    }

    entradas.sort((a, b) => new Date(b.data) - new Date(a.data)).forEach(entrada => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
                    <td>${formatarData(entrada.data)}</td>
                    <td>${entrada.tipo}</td>
                    <td>${entrada.descricao || '-'}</td>
                    <td class="positive">R$ ${entrada.valor.toFixed(2)}</td>
                    <td><button class="delete-btn" onclick="excluirEntrada(${entrada.id})">🗑️ Excluir</button></td>
                `;
        tbody.appendChild(tr);
    });
}

function excluirEntrada(id) {
    if (confirm('Tem certeza que deseja excluir esta entrada?')) {
        entradas = entradas.filter(e => e.id.toString() !== id.toString());
        salvarDados();
        atualizarTabelaEntradas();
        mostrarNotificacao('Entrada excluída com sucesso!', 'info');
    }
}

// Funções de saída
function adicionarSaida() {
    const data = document.getElementById('dataSaida').value;
    const tipo = document.getElementById('tipoSaida').value;
    const categoria = document.getElementById('categoriaSaida').value;
    const descricao = document.getElementById('descricaoSaida').value.trim();
    const valor = parseFloat(document.getElementById('valorSaida').value);

    // Validações melhoradas
    if (!data) {
        alert('Por favor, selecione uma data!');
        return;
    }

    if (!tipo) {
        alert('Por favor, selecione um tipo de saída!');
        return;
    }

    if (!categoria) {
        alert('Por favor, selecione uma categoria!');
        return;
    }

    if (!descricao) {
        alert('Por favor, insira uma descrição!');
        return;
    }

    if (!valor || valor <= 0 || isNaN(valor)) {
        alert('Por favor, insira um valor válido maior que zero!');
        return;
    }

    // Validação específica para cartão de crédito
    let cartaoId = null;
    if (tipo === 'Cartão de Crédito') {
        cartaoId = document.getElementById('cartaoSaida').value;
        if (!cartaoId) {
            alert('Por favor, selecione um cartão de crédito!');
            return;
        }
    }

    const saida = {
        id: (Date.now() + Math.random()).toString(), // ID único mais robusto
        data,
        tipo,
        categoria,
        descricao,
        valor,
        cartaoId
    };

    saidas.push(saida);
    salvarDados();
    atualizarTabelaSaidas();
    limparFormularioSaida();

    // Atualizar resumo de cartões se necessário
    if (tipo === 'Cartão de Crédito') {
        atualizarResumoCartoes();
    }

    // Feedback visual
    mostrarNotificacao('Saída adicionada com sucesso!', 'success');
}

function limparFormularioSaida() {
    document.getElementById('dataSaida').value = '';
    document.getElementById('tipoSaida').value = '';
    document.getElementById('categoriaSaida').innerHTML = '<option value="">Selecione o tipo primeiro...</option>';
    document.getElementById('descricaoSaida').value = '';
    document.getElementById('valorSaida').value = '';
    document.getElementById('cartaoSaida').value = '';
    document.getElementById('cartaoGroup').style.display = 'none';
}

function atualizarTabelaSaidas() {
    const tbody = document.querySelector('#tabelaSaidas tbody');
    if (!tbody) return;

    tbody.innerHTML = '';

    if (saidas.length === 0) {
        tbody.innerHTML = '<tr><td colspan="7" style="text-align: center; color: #6c757d;">Nenhuma saída registrada</td></tr>';
        return;
    }

    saidas.sort((a, b) => new Date(b.data) - new Date(a.data)).forEach(saida => {
        const nomeCartao = saida.cartaoId ? obterNomeCartao(saida.cartaoId) : '-';
        const tr = document.createElement('tr');
        tr.innerHTML = `
                    <td>${formatarData(saida.data)}</td>
                    <td>${saida.tipo}</td>
                    <td>${saida.categoria}</td>
                    <td>${saida.descricao}</td>
                    <td>${nomeCartao}</td>
                    <td class="negative">R$ ${saida.valor.toFixed(2)}</td>
                    <td><button class="delete-btn" onclick="excluirSaida(${saida.id})">🗑️ Excluir</button></td>
                `;
        tbody.appendChild(tr);
    });
}

function excluirSaida(id) {
    if (confirm('Tem certeza que deseja excluir esta saída?')) {
        saidas = saidas.filter(s => s.id.toString() !== id.toString());
        salvarDados();
        atualizarTabelaSaidas();
        mostrarNotificacao('Saída excluída com sucesso!', 'info');
    }
}

// Funções de resumo
function atualizarResumo() {
    const filtro = document.getElementById('filtroMes').value;
    let entradasFiltradas = entradas;
    let saidasFiltradas = saidas;

    if (filtro) {
        const [ano, mes] = filtro.split('-');
        entradasFiltradas = entradas.filter(e => {
            const dataEntrada = new Date(e.data);
            return dataEntrada.getFullYear() == ano && (dataEntrada.getMonth() + 1) == mes;
        });
        saidasFiltradas = saidas.filter(s => {
            const dataSaida = new Date(s.data);
            return dataSaida.getFullYear() == ano && (dataSaida.getMonth() + 1) == mes;
        });
    }

    const totalEntradas = entradasFiltradas.reduce((sum, e) => sum + e.valor, 0);
    const totalSaidas = saidasFiltradas.reduce((sum, s) => sum + s.valor, 0);
    const saldo = totalEntradas - totalSaidas;

    // Calcular total de gastos em cartões
    const totalCartoes = saidasFiltradas
        .filter(s => s.tipo === 'Cartão de Crédito')
        .reduce((sum, s) => sum + s.valor, 0);

    // Atualizar cards de resumo
    const cardsContainer = document.getElementById('cardsResumo');
    if (cardsContainer) {
        cardsContainer.innerHTML = `
                    <div class="total-card" style="background: linear-gradient(135deg, #28a745, #20c997);">
                        <h4>Total de Entradas</h4>
                        <div class="value">R$ ${totalEntradas.toFixed(2)}</div>
                    </div>
                    <div class="total-card" style="background: linear-gradient(135deg, #dc3545, #c82333);">
                        <h4>Total de Saídas</h4>
                        <div class="value">R$ ${totalSaidas.toFixed(2)}</div>
                    </div>
                    <div class="total-card" style="background: linear-gradient(135deg, #6f42c1, #5a379a);">
                        <h4>Gastos em Cartões</h4>
                        <div class="value">R$ ${totalCartoes.toFixed(2)}</div>
                    </div>
                    <div class="total-card" style="background: linear-gradient(135deg, ${saldo >= 0 ? '#17a2b8, #138496' : '#fd7e14, #e2620b'});">
                        <h4>Saldo</h4>
                        <div class="value">R$ ${saldo.toFixed(2)}</div>
                    </div>
                `;
    }

    // Atualizar tabela de resumo por categoria
    atualizarResumoCategoria(saidasFiltradas);
}

function atualizarResumoCategoria(saidasFiltradas) {
    const tbody = document.querySelector('#tabelaResumoCategoria tbody');
    if (!tbody) return;

    tbody.innerHTML = '';

    if (saidasFiltradas.length === 0) {
        tbody.innerHTML = '<tr><td colspan="3" style="text-align: center; color: #6c757d;">Nenhuma saída no período selecionado</td></tr>';
        return;
    }

    const resumoPorCategoria = {};
    let totalGeral = 0;

    saidasFiltradas.forEach(saida => {
        if (!resumoPorCategoria[saida.categoria]) {
            resumoPorCategoria[saida.categoria] = 0;
        }
        resumoPorCategoria[saida.categoria] += saida.valor;
        totalGeral += saida.valor;
    });

    Object.entries(resumoPorCategoria)
        .sort((a, b) => b[1] - a[1])
        .forEach(([categoria, valor]) => {
            const percentual = totalGeral > 0 ? (valor / totalGeral * 100).toFixed(1) : 0;
            const tr = document.createElement('tr');
            tr.innerHTML = `
                        <td>${categoria}</td>
                        <td class="negative">R$ ${valor.toFixed(2)}</td>
                        <td>${percentual}%</td>
                    `;
            tbody.appendChild(tr);
        });
}

// Funções de gráficos
let graficoEntradasSaidas, graficoCategorias, graficoSaldo;

function atualizarGraficos() {
    try {
        atualizarGraficoEntradasSaidas();
        atualizarGraficoCategorias();
        atualizarGraficoSaldo();
    } catch (error) {
        console.error('Erro ao atualizar gráficos:', error);
        mostrarNotificacao('Erro ao carregar gráficos. Verifique se o Chart.js está carregado.', 'error');
    }
}

function atualizarGraficoEntradasSaidas() {
    const canvas = document.getElementById('graficoEntradasSaidas');
    if (!canvas) return;

    const ctx = canvas.getContext('2d');

    if (graficoEntradasSaidas) {
        graficoEntradasSaidas.destroy();
    }

    // Agrupar por mês
    const dadosPorMes = {};

    entradas.forEach(entrada => {
        const mes = entrada.data.substring(0, 7);
        if (!dadosPorMes[mes]) dadosPorMes[mes] = { entradas: 0, saidas: 0 };
        dadosPorMes[mes].entradas += entrada.valor;
    });

    saidas.forEach(saida => {
        const mes = saida.data.substring(0, 7);
        if (!dadosPorMes[mes]) dadosPorMes[mes] = { entradas: 0, saidas: 0 };
        dadosPorMes[mes].saidas += saida.valor;
    });

    const meses = Object.keys(dadosPorMes).sort();

    if (meses.length === 0) {
        canvas.style.display = 'none';
        return;
    }

    canvas.style.display = 'block';
    const dadosEntradas = meses.map(mes => dadosPorMes[mes].entradas);
    const dadosSaidas = meses.map(mes => dadosPorMes[mes].saidas);

    graficoEntradasSaidas = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: meses.map(mes => {
                const [ano, mesNum] = mes.split('-');
                return `${mesNum}/${ano}`;
            }),
            datasets: [{
                label: 'Entradas',
                data: dadosEntradas,
                backgroundColor: 'rgba(40, 167, 69, 0.8)',
                borderColor: 'rgba(40, 167, 69, 1)',
                borderWidth: 2
            }, {
                label: 'Saídas',
                data: dadosSaidas,
                backgroundColor: 'rgba(220, 53, 69, 0.8)',
                borderColor: 'rgba(220, 53, 69, 1)',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        callback: function (value) {
                            return 'R$ ' + value.toFixed(2);
                        }
                    }
                }
            },
            plugins: {
                legend: {
                    position: 'top'
                }
            }
        }
    });
}

function atualizarGraficoCategorias() {
    const canvas = document.getElementById('graficoCategorias');
    if (!canvas) return;

    const ctx = canvas.getContext('2d');

    if (graficoCategorias) {
        graficoCategorias.destroy();
    }

    const gastosPorCategoria = {};
    saidas.forEach(saida => {
        if (!gastosPorCategoria[saida.categoria]) {
            gastosPorCategoria[saida.categoria] = 0;
        }
        gastosPorCategoria[saida.categoria] += saida.valor;
    });

    const categorias = Object.keys(gastosPorCategoria);

    if (categorias.length === 0) {
        canvas.style.display = 'none';
        return;
    }

    canvas.style.display = 'block';
    const valores = Object.values(gastosPorCategoria);
    const cores = [
        '#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0',
        '#9966FF', '#FF9F40', '#FF6384', '#C9CBCF',
        '#4BC0C0', '#FF6384', '#36A2EB', '#FFCE56'
    ];

    graficoCategorias = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: categorias,
            datasets: [{
                data: valores,
                backgroundColor: cores.slice(0, categorias.length),
                borderWidth: 2,
                borderColor: '#fff'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom'
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            const total = valores.reduce((sum, val) => sum + val, 0);
                            const percentual = ((context.parsed / total) * 100).toFixed(1);
                            return context.label + ': R$ ' + context.parsed.toFixed(2) + ' (' + percentual + '%)';
                        }
                    }
                }
            }
        }
    });
}

function atualizarGraficoSaldo() {
    const canvas = document.getElementById('graficoSaldo');
    if (!canvas) return;

    const ctx = canvas.getContext('2d');

    if (graficoSaldo) {
        graficoSaldo.destroy();
    }

    // Calcular saldo acumulado por mês
    const dadosPorMes = {};

    entradas.forEach(entrada => {
        const mes = entrada.data.substring(0, 7);
        if (!dadosPorMes[mes]) dadosPorMes[mes] = { entradas: 0, saidas: 0 };
        dadosPorMes[mes].entradas += entrada.valor;
    });

    saidas.forEach(saida => {
        const mes = saida.data.substring(0, 7);
        if (!dadosPorMes[mes]) dadosPorMes[mes] = { entradas: 0, saidas: 0 };
        dadosPorMes[mes].saidas += saida.valor;
    });

    const meses = Object.keys(dadosPorMes).sort();

    if (meses.length === 0) {
        canvas.style.display = 'none';
        return;
    }

    canvas.style.display = 'block';
    let saldoAcumulado = 0;
    const saldos = meses.map(mes => {
        saldoAcumulado += dadosPorMes[mes].entradas - dadosPorMes[mes].saidas;
        return saldoAcumulado;
    });

    graficoSaldo = new Chart(ctx, {
        type: 'line',
        data: {
            labels: meses.map(mes => {
                const [ano, mesNum] = mes.split('-');
                return `${mesNum}/${ano}`;
            }),
            datasets: [{
                label: 'Saldo Acumulado',
                data: saldos,
                borderColor: '#17a2b8',
                backgroundColor: 'rgba(23, 162, 184, 0.1)',
                borderWidth: 3,
                fill: true,
                tension: 0.4
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    ticks: {
                        callback: function (value) {
                            return 'R$ ' + value.toFixed(2);
                        }
                    }
                }
            },
            plugins: {
                legend: {
                    position: 'top'
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            return 'Saldo: R$ ' + context.parsed.y.toFixed(2);
                        }
                    }
                }
            }
        }
    });
}

// Funções de exportação
function exportarCSV() {
    try {
        let csvContent = "data:text/csv;charset=utf-8,";

        // Adicionar entradas
        csvContent += "ENTRADAS\n";
        csvContent += "Data,Tipo,Descrição,Valor\n";
        entradas.forEach(entrada => {
            csvContent += `${entrada.data},${entrada.tipo},"${entrada.descricao || ''}",${entrada.valor}\n`;
        });

        csvContent += "\nSAÍDAS\n";
        csvContent += "Data,Tipo,Categoria,Descrição,Valor\n";
        saidas.forEach(saida => {
            csvContent += `${saida.data},${saida.tipo},${saida.categoria},"${saida.descricao}",${saida.valor}\n`;
        });

        const encodedUri = encodeURI(csvContent);
        const link = document.createElement("a");
        link.setAttribute("href", encodedUri);
        link.setAttribute("download", `financeiro_${new Date().toISOString().split('T')[0]}.csv`);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        mostrarNotificacao('Arquivo CSV exportado com sucesso!', 'success');
    } catch (error) {
        console.error('Erro ao exportar CSV:', error);
        mostrarNotificacao('Erro ao exportar arquivo CSV', 'error');
    }
}

function exportarJSON() {
    try {
        const dados = {
            entradas: entradas,
            saidas: saidas,
            exportado_em: new Date().toISOString()
        };

        const dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(dados, null, 2));
        const link = document.createElement("a");
        link.setAttribute("href", dataStr);
        link.setAttribute("download", `financeiro_${new Date().toISOString().split('T')[0]}.json`);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        mostrarNotificacao('Arquivo JSON exportado com sucesso!', 'success');
    } catch (error) {
        console.error('Erro ao exportar JSON:', error);
        mostrarNotificacao('Erro ao exportar arquivo JSON', 'error');
    }
}

function imprimirRelatorio() {
    try {
        const totalEntradas = entradas.reduce((sum, e) => sum + e.valor, 0);
        const totalSaidas = saidas.reduce((sum, s) => sum + s.valor, 0);
        const saldo = totalEntradas - totalSaidas;

        const janela = window.open('', '_blank');
        janela.document.write(`
                    <html>
                    <head>
                        <title>Relatório Financeiro</title>
                        <style>
                            body { font-family: Arial, sans-serif; margin: 20px; }
                            h1 { color: #2c3e50; }
                            table { width: 100%; border-collapse: collapse; margin: 20px 0; }
                            th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                            th { background-color: #f2f2f2; }
                            .total { font-weight: bold; }
                            .positive { color: green; }
                            .negative { color: red; }
                        </style>
                    </head>
                    <body>
                        <h1>Relatório Financeiro Pessoal</h1>
                        <p><strong>Gerado em:</strong> ${new Date().toLocaleDateString('pt-BR')}</p>
                        
                        <h2>Resumo Geral</h2>
                        <p class="positive">Total de Entradas: R$ ${totalEntradas.toFixed(2)}</p>
                        <p class="negative">Total de Saídas: R$ ${totalSaidas.toFixed(2)}</p>
                        <p class="total">Saldo: R$ ${saldo.toFixed(2)}</p>
                        
                        <h2>Entradas</h2>
                        <table>
                            <thead>
                                <tr><th>Data</th><th>Tipo</th><th>Descrição</th><th>Valor</th></tr>
                            </thead>
                            <tbody>
                                ${entradas.map(e => `
                                    <tr>
                                        <td>${formatarData(e.data)}</td>
                                        <td>${e.tipo}</td>
                                        <td>${e.descricao || '-'}</td>
                                        <td class="positive">R$ ${e.valor.toFixed(2)}</td>
                                    </tr>
                                `).join('')}
                            </tbody>
                        </table>
                        
                        <h2>Saídas</h2>
                        <table>
                            <thead>
                                <tr><th>Data</th><th>Tipo</th><th>Categoria</th><th>Descrição</th><th>Valor</th></tr>
                            </thead>
                            <tbody>
                                ${saidas.map(s => `
                                    <tr>
                                        <td>${formatarData(s.data)}</td>
                                        <td>${s.tipo}</td>
                                        <td>${s.categoria}</td>
                                        <td>${s.descricao}</td>
                                        <td class="negative">R$ ${s.valor.toFixed(2)}</td>
                                    </tr>
                                `).join('')}
                            </tbody>
                        </table>
                    </body>
                    </html>
                `);
        janela.document.close();
        janela.print();

        mostrarNotificacao('Relatório enviado para impressão!', 'success');
    } catch (error) {
        console.error('Erro ao imprimir relatório:', error);
        mostrarNotificacao('Erro ao gerar relatório para impressão', 'error');
    }
}

// Funções auxiliares
function formatarData(data) {
    try {
        return new Date(data + 'T00:00:00').toLocaleDateString('pt-BR');
    } catch (error) {
        return data;
    }
}

function salvarDados() {
    try {
        localStorage.setItem('entradas', JSON.stringify(entradas));
        localStorage.setItem('saidas', JSON.stringify(saidas));
        localStorage.setItem('cartoes', JSON.stringify(cartoes));
    } catch (error) {
        console.error('Erro ao salvar dados:', error);
        mostrarNotificacao('Erro ao salvar dados no navegador', 'error');
    }
}

function mostrarNotificacao(mensagem, tipo = 'info') {
    // Criar elemento de notificação
    const notificacao = document.createElement('div');
    notificacao.style.cssText = `
                position: fixed;
                top: 20px;
                right: 20px;
                padding: 15px 20px;
                border-radius: 8px;
                color: white;
                font-weight: 600;
                z-index: 10000;
                animation: slideIn 0.3s ease-out;
                max-width: 300px;
                word-wrap: break-word;
            `;

    // Definir cor baseada no tipo
    const cores = {
        success: '#28a745',
        error: '#dc3545',
        info: '#17a2b8',
        warning: '#ffc107'
    };

    notificacao.style.backgroundColor = cores[tipo] || cores.info;
    notificacao.textContent = mensagem;

    // Adicionar ao DOM
    document.body.appendChild(notificacao);

    // Remover após 3 segundos
    setTimeout(() => {
        notificacao.style.animation = 'slideOut 0.3s ease-in';
        setTimeout(() => {
            if (notificacao.parentNode) {
                notificacao.parentNode.removeChild(notificacao);
            }
        }, 300);
    }, 3000);
}

// Adicionar estilos CSS para animações de notificação
const style = document.createElement('style');
style.textContent = `
            @keyframes slideIn {
                from { transform: translateX(100%); opacity: 0; }
                to { transform: translateX(0); opacity: 1; }
            }
            @keyframes slideOut {
                from { transform: translateX(0); opacity: 1; }
                to { transform: translateX(100%); opacity: 0; }
            }
        `;
document.head.appendChild(style);

// Função para limpar todos os dados
function limparTodosDados() {
    if (confirm('ATENÇÃO: Esta ação irá apagar TODOS os dados da planilha financeira (entradas, saídas e cartões). Esta ação não pode ser desfeita!\n\nTem certeza que deseja continuar?')) {
        if (confirm('Última confirmação: Você realmente quer apagar todos os dados?')) {
            try {
                entradas = [];
                saidas = [];
                cartoes = [];
                localStorage.removeItem('entradas');
                localStorage.removeItem('saidas');
                localStorage.removeItem('cartoes');

                atualizarTabelaEntradas();
                atualizarTabelaSaidas();
                atualizarCartoesGrid();
                atualizarSelectCartoes();
                atualizarResumoCartoes();
                atualizarResumo();

                // Destruir gráficos se existirem
                if (graficoEntradasSaidas) {
                    graficoEntradasSaidas.destroy();
                    graficoEntradasSaidas = null;
                }
                if (graficoCategorias) {
                    graficoCategorias.destroy();
                    graficoCategorias = null;
                }
                if (graficoSaldo) {
                    graficoSaldo.destroy();
                    graficoSaldo = null;
                }

                mostrarNotificacao('Todos os dados foram apagados com sucesso!', 'info');
            } catch (error) {
                console.error('Erro ao limpar dados:', error);
                mostrarNotificacao('Erro ao limpar dados', 'error');
            }
        }
    }
}

// Inicialização
document.addEventListener('DOMContentLoaded', function () {
    try {
        // Definir data atual como padrão
        const hoje = new Date().toISOString().split('T')[0];
        const dataEntrada = document.getElementById('dataEntrada');
        const dataSaida = document.getElementById('dataSaida');

        if (dataEntrada) dataEntrada.value = hoje;
        if (dataSaida) dataSaida.value = hoje;

        // Definir mês atual como padrão no filtro
        const mesAtual = new Date().toISOString().substring(0, 7);
        const filtroMes = document.getElementById('filtroMes');
        if (filtroMes) filtroMes.value = mesAtual;

        // Carregar dados existentes
        atualizarTabelaEntradas();
        atualizarTabelaSaidas();
        atualizarResumo();

        // Verificar se Chart.js está carregado
        if (typeof Chart === 'undefined') {
            console.warn('Chart.js não foi carregado. Os gráficos não funcionarão.');
            mostrarNotificacao('Chart.js não foi carregado. Os gráficos não estarão disponíveis.', 'warning');
        }

        mostrarNotificacao('Planilha Financeira carregada com sucesso!', 'success');
    } catch (error) {
        console.error('Erro na inicialização:', error);
        mostrarNotificacao('Erro ao inicializar a aplicação', 'error');
    }
});

// ==================== FUNÇÕES DE CARTÕES DE CRÉDITO ====================

// Adicionar novo cartão
function adicionarCartao() {
    const nome = document.getElementById('nomeCartao').value.trim();
    const limite = parseFloat(document.getElementById('limiteCartao').value);
    const vencimento = parseInt(document.getElementById('vencimentoCartao').value);
    const cor = document.getElementById('corCartao').value;

    // Validações
    if (!nome) {
        mostrarToast('Por favor, insira o nome do cartão!', 'error');
        return;
    }

    if (!limite || limite <= 0 || isNaN(limite)) {
        mostrarToast('Por favor, insira um limite válido maior que zero!', 'error');
        return;
    }

    if (!vencimento || vencimento < 1 || vencimento > 31) {
        mostrarToast('Por favor, insira um dia de vencimento válido (1-31)!', 'error');
        return;
    }

    // Verificar se já existe cartão com mesmo nome
    if (cartoes.some(c => c.nome.toLowerCase() === nome.toLowerCase())) {
        mostrarToast('Já existe um cartão com este nome!', 'error');
        return;
    }

    const cartao = {
        id: (Date.now() + Math.random()).toString(), // ID único como string
        nome,
        limite,
        vencimento,
        cor,
        ativo: true
    };

    cartoes.push(cartao);
    salvarDados();
    atualizarCartoesGrid();
    atualizarSelectCartoes();
    atualizarResumoCartoes();
    limparFormularioCartao();

    mostrarToast('Cartão adicionado com sucesso!', 'success');
}

// Limpar formulário de cartão
function limparFormularioCartao() {
    document.getElementById('nomeCartao').value = '';
    document.getElementById('limiteCartao').value = '';
    document.getElementById('vencimentoCartao').value = '';
    document.getElementById('corCartao').value = '#007bff';
}

// Atualizar grid de cartões
function atualizarCartoesGrid() {
    const grid = document.getElementById('cartoesGrid');
    if (!grid) return;

    grid.innerHTML = '';

    if (cartoes.length === 0) {
        grid.innerHTML = '<p style="text-align: center; color: #6c757d; grid-column: 1/-1;">Nenhum cartão cadastrado</p>';
        return;
    }

    cartoes.forEach(cartao => {
        const gastoAtual = calcularGastoCartao(cartao.id);
        const disponivel = cartao.limite - gastoAtual;
        const percentualUtilizado = cartao.limite > 0 ? (gastoAtual / cartao.limite) * 100 : 0;

        let progressClass = '';
        if (percentualUtilizado >= 90) progressClass = 'danger';
        else if (percentualUtilizado >= 70) progressClass = 'warning';

        const cartaoCard = document.createElement('div');
        cartaoCard.className = 'cartao-card';
        cartaoCard.style.setProperty('--cor-cartao', cartao.cor);
        cartaoCard.style.setProperty('--cor-cartao-dark', escurecerCor(cartao.cor, 20));

        cartaoCard.innerHTML = `
            <div class="cartao-header">
                <h4 class="cartao-nome">${cartao.nome}</h4>
                <div class="cartao-actions">
                    <button class="cartao-btn" onclick="editarCartao('${cartao.id}')">✏️</button>
                    <button class="cartao-btn" onclick="excluirCartao('${cartao.id}')">🗑️</button>
                </div>
            </div>
            <div class="cartao-info">
                <div class="cartao-limite">Limite: R$ ${cartao.limite.toFixed(2)}</div>
                <div class="cartao-vencimento">Vencimento: dia ${cartao.vencimento}</div>
            </div>
            <div class="cartao-progress">
                <div class="cartao-progress-label">
                    <span>Gasto: R$ ${gastoAtual.toFixed(2)}</span>
                    <span>Disponível: R$ ${disponivel.toFixed(2)}</span>
                </div>
                <div class="cartao-progress-bar">
                    <div class="cartao-progress-fill ${progressClass}" style="width: ${Math.min(percentualUtilizado, 100)}%"></div>
                </div>
                <div style="text-align: center; margin-top: 8px; font-size: 0.9em;">
                    ${percentualUtilizado.toFixed(1)}% utilizado
                </div>
            </div>
        `;

        grid.appendChild(cartaoCard);
    });
}

// Calcular gasto atual de um cartão
function calcularGastoCartao(cartaoId) {
    return saidas
        .filter(s => s.cartaoId && s.cartaoId.toString() === cartaoId.toString())
        .reduce((total, s) => total + s.valor, 0);
}

// Obter nome do cartão pelo ID
function obterNomeCartao(cartaoId) {
    const cartao = cartoes.find(c => c.id.toString() === cartaoId.toString());
    return cartao ? cartao.nome : 'Cartão não encontrado';
}

// Atualizar select de cartões
function atualizarSelectCartoes() {
    const select = document.getElementById('cartaoSaida');
    if (!select) return;

    select.innerHTML = '<option value="">Selecione um cartão...</option>';

    cartoes.filter(c => c.ativo).forEach(cartao => {
        const option = document.createElement('option');
        option.value = cartao.id;
        option.textContent = cartao.nome;
        select.appendChild(option);
    });
}

// Atualizar resumo de cartões
function atualizarResumoCartoes() {
    const tbody = document.querySelector('#tabelaResumoCartoes tbody');
    if (!tbody) return;

    tbody.innerHTML = '';

    if (cartoes.length === 0) {
        tbody.innerHTML = '<tr><td colspan="5" style="text-align: center; color: #6c757d;">Nenhum cartão cadastrado</td></tr>';
        return;
    }

    cartoes.forEach(cartao => {
        const gastoAtual = calcularGastoCartao(cartao.id);
        const disponivel = cartao.limite - gastoAtual;
        const percentualUtilizado = cartao.limite > 0 ? (gastoAtual / cartao.limite) * 100 : 0;

        let statusClass = 'active';
        if (percentualUtilizado >= 90) statusClass = 'danger';
        else if (percentualUtilizado >= 70) statusClass = 'warning';

        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td class="cartao-nome-cell">
                <span class="status-indicator ${statusClass}"></span>
                ${cartao.nome}
            </td>
            <td class="valor-cell negative">R$ ${gastoAtual.toFixed(2)}</td>
            <td class="valor-cell">R$ ${cartao.limite.toFixed(2)}</td>
            <td class="valor-cell ${disponivel >= 0 ? 'positive' : 'negative'}">R$ ${disponivel.toFixed(2)}</td>
            <td class="valor-cell">${percentualUtilizado.toFixed(1)}%</td>
        `;
        tbody.appendChild(tr);
    });
}

// Excluir cartão
function excluirCartao(cartaoId) {
    const cartao = cartoes.find(c => c.id === cartaoId);
    if (!cartao) return;

    // Verificar se há gastos associados
    const gastosAssociados = saidas.filter(s => s.cartaoId === cartaoId);
    
    if (gastosAssociados.length > 0) {
        if (!confirm(`O cartão "${cartao.nome}" possui ${gastosAssociados.length} gasto(s) associado(s). Tem certeza que deseja excluí-lo? Os gastos serão mantidos mas ficarão sem cartão associado.`)) {
            return;
        }
        
        // Remover associação dos gastos
        saidas.forEach(s => {
            if (s.cartaoId === cartaoId) {
                s.cartaoId = null;
            }
        });
    } else {
        if (!confirm(`Tem certeza que deseja excluir o cartão "${cartao.nome}"?`)) {
            return;
        }
    }

    cartoes = cartoes.filter(c => c.id !== cartaoId);
    salvarDados();
    atualizarCartoesGrid();
    atualizarSelectCartoes();
    atualizarResumoCartoes();
    atualizarTabelaSaidas();

    mostrarToast('Cartão excluído com sucesso!', 'info');
}

// Editar cartão (função básica - pode ser expandida com modal)
function editarCartao(cartaoId) {
    const cartao = cartoes.find(c => c.id === cartaoId);
    if (!cartao) return;

    const novoNome = prompt('Nome do cartão:', cartao.nome);
    if (!novoNome || novoNome.trim() === '') return;

    const novoLimite = prompt('Limite do cartão:', cartao.limite);
    if (!novoLimite || isNaN(novoLimite) || parseFloat(novoLimite) <= 0) return;

    const novoVencimento = prompt('Dia do vencimento (1-31):', cartao.vencimento);
    if (!novoVencimento || isNaN(novoVencimento) || parseInt(novoVencimento) < 1 || parseInt(novoVencimento) > 31) return;

    // Verificar se já existe cartão com mesmo nome (exceto o atual)
    if (cartoes.some(c => c.id !== cartaoId && c.nome.toLowerCase() === novoNome.trim().toLowerCase())) {
        mostrarToast('Já existe um cartão com este nome!', 'error');
        return;
    }

    cartao.nome = novoNome.trim();
    cartao.limite = parseFloat(novoLimite);
    cartao.vencimento = parseInt(novoVencimento);

    salvarDados();
    atualizarCartoesGrid();
    atualizarSelectCartoes();
    atualizarResumoCartoes();
    atualizarTabelaSaidas();

    mostrarToast('Cartão atualizado com sucesso!', 'success');
}

// Função auxiliar para escurecer cor
function escurecerCor(cor, porcentagem) {
    const num = parseInt(cor.replace("#", ""), 16);
    const amt = Math.round(2.55 * porcentagem);
    const R = (num >> 16) - amt;
    const G = (num >> 8 & 0x00FF) - amt;
    const B = (num & 0x0000FF) - amt;
    return "#" + (0x1000000 + (R < 255 ? R < 1 ? 0 : R : 255) * 0x10000 +
        (G < 255 ? G < 1 ? 0 : G : 255) * 0x100 +
        (B < 255 ? B < 1 ? 0 : B : 255)).toString(16).slice(1);
}

// ==================== FUNÇÕES DE NOTIFICAÇÃO MELHORADAS ====================

// Mostrar toast notification
function mostrarToast(mensagem, tipo = 'info') {
    // Remover toasts existentes
    document.querySelectorAll('.toast').forEach(toast => toast.remove());

    const toast = document.createElement('div');
    toast.className = `toast ${tipo}`;
    toast.textContent = mensagem;

    document.body.appendChild(toast);

    // Mostrar toast
    setTimeout(() => toast.classList.add('show'), 100);

    // Remover toast após 4 segundos
    setTimeout(() => {
        toast.classList.remove('show');
        setTimeout(() => toast.remove(), 300);
    }, 4000);
}

// Manter função antiga para compatibilidade
function mostrarNotificacao(mensagem, tipo) {
    mostrarToast(mensagem, tipo);
}

// ==================== MELHORIAS NA FUNÇÃO SALVAR DADOS ====================

function salvarDados() {
    try {
        localStorage.setItem('entradas', JSON.stringify(entradas));
        localStorage.setItem('saidas', JSON.stringify(saidas));
        localStorage.setItem('cartoes', JSON.stringify(cartoes));
    } catch (error) {
        console.error('Erro ao salvar dados:', error);
        mostrarToast('Erro ao salvar dados no navegador', 'error');
    }
}

// ==================== INICIALIZAÇÃO ====================

// Inicializar aplicação quando a página carregar
document.addEventListener('DOMContentLoaded', function() {
    // Atualizar tabelas
    atualizarTabelaEntradas();
    atualizarTabelaSaidas();
    
    // Atualizar cartões se a aba estiver ativa
    if (document.getElementById('cartoes').classList.contains('active')) {
        atualizarCartoesGrid();
        atualizarResumoCartoes();
    }
    
    // Atualizar select de cartões
    atualizarSelectCartoes();
    
    // Definir data padrão como hoje
    const hoje = new Date().toISOString().split('T')[0];
    document.getElementById('dataEntrada').value = hoje;
    document.getElementById('dataSaida').value = hoje;
    
    // Definir mês atual no filtro
    const mesAtual = new Date().toISOString().slice(0, 7);
    document.getElementById('filtroMes').value = mesAtual;
});

