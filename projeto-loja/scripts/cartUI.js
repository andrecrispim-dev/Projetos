export class CartUI {
    constructor(cart) {
        this.cart = cart;
        this.cartPanel = document.getElementById('carrinho');
        this.cartList = document.getElementById('lista-carrinho');
        this.setupEventListeners();
        this.updateCartUI();
    }

    setupEventListeners() {
        // Botão abrir carrinho
        document.getElementById('abrir-carrinho').addEventListener('click', () => {
            this.cartPanel.classList.add('aberto');
        });

        // Botão fechar carrinho
        document.getElementById('fechar-carrinho').addEventListener('click', () => {
            this.cartPanel.classList.remove('aberto');
        });

        // Fechar com ESC
        document.addEventListener('keydown', (event) => {
            if (event.key === 'Escape') {
                this.cartPanel.classList.remove('aberto');
            }
        });

        // Botão finalizar compra
        document.getElementById('finalizar-compra').addEventListener('click', () => {
            this.finalizarCompra();
        });

        // Atualizar UI quando o carrinho mudar
        this.cart.addListener(() => this.updateCartUI());
    }

    updateCartUI() {
        this.cartList.innerHTML = '';

        if (this.cart.items.length === 0) {
            this.cartList.innerHTML = '<li class="empty-cart">Seu carrinho está vazio</li>';
            return;
        }

        this.cart.items.forEach(item => {
            const li = document.createElement('li');
            li.innerHTML = `
                <h3>${item.name}</h3>
                <div class="linha-carrinho">
                    <div class="preco-quantidade">
                        <p>Preço: R$ ${item.price}</p>
                        <div class="quantidade">
                            <button class="menos">-</button>
                            <span>${item.quantity}</span>
                            <button class="mais">+</button>
                        </div>
                    </div>
                    <button class="remover">
                        <img src="img/lixo.png" alt="Remover">
                    </button>
                </div>
            `;

            // Eventos dos botões
            const menosBtn = li.querySelector('.menos');
            const maisBtn = li.querySelector('.mais');
            const removerBtn = li.querySelector('.remover');

            menosBtn.addEventListener('click', () => {
                if (item.quantity > 1) {
                    this.cart.updateQuantity(item.name, item.quantity - 1);
                }
            });

            maisBtn.addEventListener('click', () => {
                this.cart.updateQuantity(item.name, item.quantity + 1);
            });

            removerBtn.addEventListener('click', () => {
                this.cart.removeItem(item.name);
            });

            this.cartList.appendChild(li);
        });

        // Adiciona o total
        const totalElement = document.createElement('li');
        totalElement.className = 'cart-total';
        totalElement.innerHTML = `<strong>Total: R$ ${this.cart.getTotal()}</strong>`;
        this.cartList.appendChild(totalElement);
    }

    finalizarCompra() {
        if (this.cart.items.length === 0) {
            this.cart.showNotification('Seu carrinho está vazio!', 'error');
            return;
        }

        // Aqui você pode adicionar integração com sistema de pagamento
        alert(`Total da compra: R$ ${this.cart.getTotal()}\nCompra finalizada com sucesso!`);
        this.cart.clear();
        this.cartPanel.classList.remove('aberto');
    }
} 