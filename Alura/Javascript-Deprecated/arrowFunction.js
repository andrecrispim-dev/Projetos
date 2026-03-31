// Função de calculadora simples
function calculadoraSimples(a, b, operacao) {
    let resultado;
    if (operacao === 'soma') {
        resultado = a + b;
    } else if (operacao === 'subtracao') {
        resultado = a - b;
    } else if (operacao === 'multiplicacao') {
        resultado = a * b;
    } else if (operacao === 'divisao') {
        resultado = a / b;
    } else {
        resultado = 'Operação não reconhecida';
    }
    return resultado;
}

const calculadoraArrow = (a, b, operacao) => {
    if (operacao === 'soma') {
        return a + b;
    } else if (operacao === 'subtracao') {
        return a - b;
    } else if (operacao === 'multiplicacao') {
        return a * b;
    } else if (operacao === 'divisao') {
        return a / b;
    } else {
        return 'Operação não reconhecida';
    }
}

//Crie uma função que receba o nome de uma pessoa como argumento e retorne uma saudação personalizada. Em seguida, chame a função e exiba a saudação no console.

const saudacao = (nome) => {
    return `Olá, ${nome}!`;
}

console.log(saudacao('Maria'));

//Crie uma função que receba a idade de uma pessoa e retorne se ela é maior de idade (idade >= 18). Imprima o resultado no console.

const maiorDeIdade = (idade) => {
    if (idade >= 18) {
        return 'Você é maior de idade.';
    }
}

console.log(maiorDeIdade(18));

//Crie uma função que receba uma string e verifique se é um palíndromo (uma palavra que é lida da mesma forma de trás para frente) utilizando o método de string reverse(). Retorne true se for um palíndromo e false caso contrário. Imprima o resultado no console.

const palindromo = (string) => {
    if (string === string.split('').reverse().join('')) {
        return true;
    } else {
        return false;
    }
}

console.log(palindromo('ana'));

//Crie uma função que receba três números como parâmetros e determine qual é o maior entre eles. Utilize estruturas condicionais (if, else) para comparar os valores e determinar o maior. Imprima o maior valor no console.

const maiorNumero = (a, b, c) => {
    if (a > b && a > c) {
        return a;
    } else if (b > a && b > c) {
        return b;
    } else {
        return c;
    }
}

console.log(maiorNumero(10, 20, 3));

//Crie uma arrow function chamada calculaPotencia que receba dois parâmetros: a base e o expoente. A função deve calcular a potência da base elevada ao expoente e retornar o resultado.

const calculaPotencia = (base, expoente) => {
    return base ** expoente;
}

console.log(calculaPotencia(2, 3));