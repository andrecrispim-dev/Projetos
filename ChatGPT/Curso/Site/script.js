let carrinho = [];

function adicionarAoCarrinho(nome, preco) {
    carrinho.push({ nome, preco });
    atualizarCarrinho();
}

function atualizarCarrinho() {
    const carrinhoUl = document.getElementById('itens-carrinho');
    carrinhoUl.innerHTML = '';
    let total = 0;

    carrinho.forEach(item => {
        const li = document.createElement('li');
        li.textContent = `${item.nome} - R$ ${item.preco.toFixed(2)}`;
        carrinhoUl.appendChild(li);
        total += item.preco;
    });

    document.getElementById('total-carrinho').textContent = `Total: R$ ${total.toFixed(2)}`;
}

function finalizarCompra() {
    if (carrinho.length === 0) {
        alert('O carrinho está vazio!');
        return;
    }
    alert('Compra finalizada com sucesso!');
    carrinho = [];
    atualizarCarrinho();
}

// Função de login (não funcional, apenas para demonstração)
document.getElementById('form-login').addEventListener('submit', function (e) {
    e.preventDefault();
    const email = document.getElementById('email').value;
    const senha = document.getElementById('senha').value;
    alert(`Login realizado com sucesso! Bem-vindo, ${email}`);
});
