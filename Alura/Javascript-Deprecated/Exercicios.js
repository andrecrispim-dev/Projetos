let nome = "João";
let idade = 20;
let status = true;

console.log(typeof nome, typeof idade, typeof status);

let primeiroNome = "André";
let segundoNome = "Lima";
let nomeCompleto = `${primeiroNome} ${segundoNome}`;

console.log(nomeCompleto);

const estudante = 'Caroline';

if (1 > 0) {
  console.log(estudante);
}

console.log(estudante);

const cifrao = '\u0024'
const aMaiusculo = '\u0041'
const tique = '\u2705'
const hiragana = '\u3041'

console.log(cifrao)
console.log(aMaiusculo)
console.log(tique)
console.log(hiragana)

let valor1 = 0
let abacate
let valor2 = "10"

console.log("valor1 é do tipo:", typeof valor1)
console.log("abacate é do tipo:", typeof abacate)
console.log("valor2 é do tipo:", typeof valor2)

const estaAprovado = true;
if (estaAprovado) {
    console.log("Parabéns! Você foi aprovado.");
}

Number("1"); // retorna o número 1 
Number("Alura"); // retorna NaN
Number(undefined); // retorna NaN
Number(null); // retorna 0
console.log(Number(true));
console.log(Number(false));

let frase = "Olá, mundo!";

const notaPrimeiroBi = 8;
const notaSegundoBi = 6.3;
const notaTerceiroBi = 7;
const notaQuartoBi = 9.3;

let media = (notaPrimeiroBi + notaSegundoBi + notaTerceiroBi + notaQuartoBi) / 4;

if (media >= 7) {
 media += media * 0.1;
}

console.log(`a média é ${media.toFixed(2)}`);

const salarioMensal = 3500; 
const despesasFixas = 1200; 
const despesasVariaveis = 500; 
const economiasMensais = 800;
const bonusAnual = 3000;

console.log((salarioMensal - despesasFixas - despesasVariaveis) * 12 );
console.log(economiasMensais * 12);
console.log(bonusAnual);

const resultado = (salarioMensal - despesasFixas - despesasVariaveis) * 12 + (economiasMensais * 12) + bonusAnual;

console.log(resultado)

let resultado2;
resultado2 = 10 + 5 * 2 / 3 - 7 + 15 * 3 / 5 + 20 - 4 * 2;
console.log("O resultado da expressão é:", resultado2.toFixed(2));

let contadorVisitas = 0;
contadorVisitas = contadorVisitas + 1;
contadorVisitas += 1;
contadorVisitas++;

let estoqueProdutoA = 50;

function realizarVenda(quantidade){
    if (estoqueProdutoA >= quantidade){
        estoqueProdutoA -= quantidade;
        console.log(`Venda realizada com sucesso. Estoque atual: ${estoqueProdutoA}`);
    } else {
        console.log(`Desculpe, não temos estoque suficiente. Estoque atual: ${estoqueProdutoA}`);
    }
}

