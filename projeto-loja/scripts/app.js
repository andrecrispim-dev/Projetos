import { Cart } from './cart.js';
import { CartUI } from './cartUI.js';
import { ProductManager } from './products.js';

// Inicialização da aplicação
document.addEventListener('DOMContentLoaded', () => {
    try {
        // Criar instância do carrinho
        const cart = new Cart();

        // Inicializar UI do carrinho
        const cartUI = new CartUI(cart);

        // Inicializar gerenciador de produtos
        const productManager = new ProductManager(cart);

    } catch (error) {
        console.error('Erro ao inicializar a aplicação:', error);
        showErrorMessage('Erro ao carregar a aplicação. Por favor, recarregue a página.');
    }
});

function showErrorMessage(message) {
    const errorDiv = document.createElement('div');
    errorDiv.className = 'error-message';
    errorDiv.textContent = message;
    document.body.appendChild(errorDiv);
}

const botaoCarrinho = document.getElementById('abrir-carrinho');
const painelCarrinho = document.getElementById('carrinho');

function abrirCarrinho() {
    painelCarrinho.classList.add('aberto');
}

botaoCarrinho.addEventListener('click', abrirCarrinho);

const botaoFechar = document.getElementById('fechar-carrinho');

function fecharCarrinho() {
    painelCarrinho.classList.remove('aberto');
}

botaoFechar.addEventListener('click', fecharCarrinho);

document.addEventListener('keydown', function (event) {
    if (event.key === 'Escape') {
        fecharCarrinho();
    }
});

document.querySelectorAll('.mais').forEach(botao => {
    botao.addEventListener('click', () => {
        const span = botao.parentElement.querySelector('span');
        let qtd = parseInt(span.textContent);
        span.textContent = qtd + 1;
    });
});

document.querySelectorAll('.menos').forEach(botao => {
    botao.addEventListener('click', () => {
        const span = botao.parentElement.querySelector('span');
        let qtd = parseInt(span.textContent);
        if (qtd > 1) {
            span.textContent = qtd - 1;
        }
    });
});

document.querySelectorAll('.remover').forEach(botao => {
    botao.addEventListener('click', () => {
        const li = botao.closest('li');
        li.remove();
    });
});

document.querySelectorAll('.adicionar').forEach(botao => {
    botao.addEventListener('click', () => {
        const card = botao.closest('.produto'); // sobe até o card do produto

        const nome = card.querySelector('h2').textContent; // pega o nome
        const preco = card.querySelector('p').textContent.replace('Preço: R$ ', ''); // pega o preço
        const quantidade = card.querySelector('.quantidade span').textContent; // pega a quantidade

        // Cria um novo item de carrinho
        const item = document.createElement('li');
        item.innerHTML = `
        <h3>${nome}</h3>
        <div class="linha-carrinho">
          <div class="preco-quantidade">
            <p>Preço: R$ ${preco}</p>
            <div class="quantidade">
              <button class="menos">-</button>
              <span>${quantidade}</span>
              <button class="mais">+</button>
            </div>
          </div>
          <button class="remover">
            <img src="img/lixo.png" alt="Remover">
          </button>
        </div>
      `;

        document.getElementById('lista-carrinho').appendChild(item);

        // Reaplica os eventos para os novos botões
        atualizarEventos();
    });
});

function atualizarEventos() {
    document.querySelectorAll('.mais').forEach(botao => {
        botao.onclick = () => {
            const span = botao.parentElement.querySelector('span');
            span.textContent = parseInt(span.textContent) + 1;
        };
    });

    document.querySelectorAll('.menos').forEach(botao => {
        botao.onclick = () => {
            const span = botao.parentElement.querySelector('span');
            const qtd = parseInt(span.textContent);
            if (qtd > 1) {
                span.textContent = qtd - 1;
            }
        };
    });

    document.querySelectorAll('.remover').forEach(botao => {
        botao.onclick = () => {
            botao.closest('li').remove();
        };
    });
}