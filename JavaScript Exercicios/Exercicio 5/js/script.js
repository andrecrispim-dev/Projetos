let contador = document.querySelector('div#contador')
let numero = 0
let horas = 0
let minutos = 0
let segundos = 0
let intervalo = null

function iniciar() {
    if (intervalo !== null) return

    intervalo = setInterval(function () {
        segundos++

        if (segundos === 60) {
            segundos = 0
            minutos++
        }

        if (minutos === 60) {
            minutos = 0
            horas++
        }

        // Formatar para 2 dígitos
        let h = horas < 10 ? '0' + horas : horas
        let m = minutos < 10 ? '0' + minutos : minutos
        let s = segundos < 10 ? '0' + segundos : segundos

        contador.textContent = `${h}:${m}:${s}`
    }, 1000)
}

function parar() {
    clearInterval(intervalo) // para a contagem
    intervalo = null         // limpa a variável
}

function zerar() {
    //parar()
    horas = 0
    minutos = 0
    segundos = 0
    contador.textContent = '00:00:00'
}