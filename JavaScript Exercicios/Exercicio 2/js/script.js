function verificar() {
    let data = new Date();
    let ano = data.getFullYear();
    let inputAno = document.getElementById('ano');
    let res = document.querySelector('div#res');
    let sexo = document.getElementsByName('sexo');



    if (inputAno.value.length == 0) {
        res.innerHTML = 'Por favor, digite um ano de nascimento!';
    } else if (inputAno.value.length != 4) {
        res.innerHTML = 'Por favor, digite um ano de nascimento válido!';
    } else if (sexo[0].checked) {
        let genero = 'Masculino';
        document.getElementById('imagem').hidden = false;
        document.body.style.background = '#838383';
        let idade = ano - inputAno.value;
        if (idade < 2) {
            res.innerHTML = `É um Bebê macho de ${idade} anos`;
            imagem.src = 'img/Homem-bebe.jpg';
        } else if (idade < 12) {
            res.innerHTML = `É um Menino de ${idade} anos`;
            imagem.src = 'img/Homem-criança.jpg';
        } else if (idade < 18) {
            res.innerHTML = `É um Boy de ${idade} anos`;
            imagem.src = 'img/Homem-adolescente.jpg';
        } else if (idade < 40) {
            res.innerHTML = `É um Mano de ${idade} anos`;
            imagem.src = 'img/Homem-jovem.jpg';
        } else if (idade < 60) {
            res.innerHTML = `É um Homem de ${idade} anos`;
            imagem.src = 'img/Homem.jpg';
        } else {
            res.innerHTML = `É um Velho de ${idade} anos`;
            imagem.src = 'img/Homem-idoso.jpg';
        }
    } else if (sexo[1].checked) {
        let genero = 'Feminino';
        document.getElementById('imagem').hidden = false;
        document.body.style.background = '#000';
        let idade = ano - inputAno.value;
        if (idade < 2) {
            res.innerHTML = `É uma Bebê fêmea de ${idade} anos`;
            imagem.src = 'img/Mulher-bebe.jpg';
        } else if (idade < 12) {
            res.innerHTML = `É uma Menina de ${idade} anos`;
            imagem.src = 'img/Mulher-criança.jpg';
        } else if (idade < 18) {
            res.innerHTML = `É uma Boyzinha de ${idade} anos`;
            imagem.src = 'img/Mulher-adolescente.jpg';
        } else if (idade < 40) {
            res.innerHTML = `É uma Bixinha de ${idade} anos`;
            imagem.src = 'img/Mulher-jovem.jpg';
        } else if (idade < 60) {
            res.innerHTML = `É uma Mulher de ${idade} anos`;
            imagem.src = 'img/Mulher.jpg';
        } else {
            res.innerHTML = `É uma Velha de ${idade} anos`;
            imagem.src = 'img/Mulher-idosa.jpg';
        }
    }
}