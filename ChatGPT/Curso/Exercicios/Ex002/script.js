let i;

function mudarCor() {
    const cores = ["#fff", "#000000"];
    const corAtual = document.body.style.backgroundColor;
  
    // Evitar repetir a mesma cor
    if (i === 0) {
        i = 1;
    }
    else
        i = 0;

    let novaCor = cores[i];
  
    document.body.style.backgroundColor = novaCor;
  }

