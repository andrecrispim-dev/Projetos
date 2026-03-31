function contar() {
    let inicio = Number(document.getElementById('inicio').value);
    let fim = Number(document.getElementById('fim').value);
    let passo = Number(document.getElementById('passo').value);

    // Limpa o conteúdo anterior antes de começar
    res.innerHTML = '';

    function validarPasso() {
        if (passo <= 0) {
            alert('Passo inválido! Considerando PASSO 1');
            passo = 1;
            document.getElementById('passo').value = passo;
        }
    }

    if (inicio < fim) { //contagem crescente
        validarPasso();
        for (let i = inicio; i <= fim; i += passo) {
            res.innerHTML += `${i} \u{1F449}`;
        }
        res.innerHTML += `\u{1F3C1}`;
    } else if (inicio > fim) { //contagem decrescente
        validarPasso();
        for (let i = inicio; i >= fim; i -= passo) {
            res.innerHTML += `${i} \u{1F449}`;
        }
        res.innerHTML += `\u{1F3C1}`;
    } else {
        res.innerHTML = 'Impossível contar!';
    }
}

function limpar() {
    document.getElementById('res').innerHTML = 'Preencha os dados acima para ver o resultado!';
    document.getElementById('inicio').value = '';
    document.getElementById('fim').value = '';
    document.getElementById('passo').value = '';
}