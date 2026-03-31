const animaisDoAquario = ['baleia', 'polvo', 'golfinho', 'tubarão']

animaisDoAquario.splice(1, 0, 'sardinha')
animaisDoAquario.splice(3, 2, 'atum')

console.log(animaisDoAquario)

const numeros = [1,2,3,4,5,6,7,8,9,10];
const parteNumeros = numeros.slice(3, 8);
console.log(parteNumeros); // [4, 5, 6, 7, 8]
