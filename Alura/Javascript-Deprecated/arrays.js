//Crie uma função que receba dois arrays e os concatene em um único array.

const array1 = [1, 3, 5];
const array2 = [2, 4, 6];
const arrayConcatenado = array1.concat(array2);
console.log(arrayConcatenado);

//Crie um array chamado numeros contendo números de 1 a 10. Utilize o método slice para criar um novo array chamado parteNumeros que contenha apenas os números de índice 3 a 7 de numeros.

const numeros = [1,2,3,4,5,6,7,8,9,10];
const parteNumeros = numeros.slice(3,8);
console.log(parteNumeros);


const frutas = ['Maçã', 'Banana', 'Laranja', 'Limão', 'Abacaxi'];
frutas.splice(2, 2, 'Kiwi', 'Pêssego');
console.log(frutas);

const menuPrincipal = ['Arroz Grego', 'Filé de Peixe', 'Costela de Porco'];
const menuDeSobremesas = ['Pudim', 'Cocada'];
const menu = menuPrincipal.concat(menuDeSobremesas);
console.log(menu);

//Crie uma lista bidimensional com 3 linhas e 3 colunas, onde cada elemento seja uma matriz 3x3 com valores iniciando em 1 e aumentando em 1 a cada elemento.

//Dicas:

//comece com um array vazio, por exemplo const matriz = [] e adicione valores nele com push;
//você pode resolver usando um for dentro de outro for.

const matriz = [];
for (let i = 0; i < 3; i++) {
  matriz.push([]);
  for (let j = 0; j < 3; j++) {
    matriz[i].push(j + 1);
  }
}
console.log(matriz);