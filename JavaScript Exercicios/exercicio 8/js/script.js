let numeros = []

function Adicionar() {
    let num = Number(document.getElementById('num').value)
    let lista = document.getElementById('lista')
    numeros.push(num)

    let option = document.createElement('option')
    option.text = `Valor ${num} adicionado.`
    option.value = num
    lista.appendChild(option)
    lista.size = lista.options.length;
}

function Finalizar() {

    let res = document.getElementById('res')

    if (numeros.length === 0) {
        res.innerHTML = 'Adicione valores antes de finalizar!'
        return
    }

    res.innerHTML = `Acima temos um total de ${numeros.length} números cadastrados<br>`
    res.innerHTML += `O maior valor informado foi ${maior(numeros)}<br>`
    res.innerHTML += `O menor valor informado foi ${menor(numeros)}<br>`
    res.innerHTML += `Somando todos os valores, temos um total de ${soma(numeros)}<br>`
    res.innerHTML += `A média dos valores digitados é ${media(numeros)}`

}
function maior(num) {
    return Math.max(...num)
}

function menor(num) {
    return Math.min(...num)
}

function soma(num) {
    return num.reduce((total, valor) => total + valor, 0)
}

function media(num) {
    return (soma(num) / num.length).toFixed(2)
}

function inLista() {

}

