function gerarTabuada() {
    let numero = Number(document.getElementById('numero').value)
    let res = document.getElementById('res')

    res.innerHTML = '';

    for (let i = 0; i <= 10; i++) {
        let option = document.createElement('option')
        option.text = `${numero} x ${i} = ${numero * i}`
        option.value = i
        res.appendChild(option)
    }
    res.size = res.options.length;
}