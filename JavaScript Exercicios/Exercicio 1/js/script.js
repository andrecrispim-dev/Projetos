let msg = document.getElementById('hora');
let img = document.getElementById('imagem');


function atualizarHora() {
    const data = new Date();
    let hora = data.getHours();
    let minuto = data.getMinutes();
    let segundo = data.getSeconds();

    hora = hora < 10 ? '0' + hora : hora;
    minuto = minuto < 10 ? '0' + minuto : minuto;
    segundo = segundo < 10 ? '0' + segundo : segundo;
    const horaAtual = `${hora}:${minuto}:${segundo}`;

    document.getElementById('hora').textContent = `Agora são ` + horaAtual;

    if (hora >= 0 && hora < 12) {
        img.src = 'img/manha500.png';
        document.body.style.background = '#e2cd9f';
    } else if (hora >= 12 && hora < 18) {
        img.src = 'img/tarde500.png';
        document.body.style.background = '#b9846f';
    } else {
        img.src = 'img/noite500.png';
        document.body.style.background = '#515154';
    }
}

setInterval(atualizarHora, 1000);

atualizarHora();


