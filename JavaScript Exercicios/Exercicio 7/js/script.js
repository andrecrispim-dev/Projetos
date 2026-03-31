function calcular() {
    let inputData = document.getElementById('dataNasc')
    let dataHoje = new Date()

    let nascimento = new Date(inputData.value)

    let diferencaEmMs = dataHoje - nascimento
    let diasVividos = Math.floor(diferencaEmMs / (1000 * 60 * 60 * 24))

    res.innerHTML = `Você já viveu aproximadamente ${diasVividos} dias.`

}