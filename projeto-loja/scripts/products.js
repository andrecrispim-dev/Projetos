export class ProductManager {
    constructor(cart) {
        this.cart = cart;
        this.setupProductEvents();
    }

    setupProductEvents() {
        // Eventos de quantidade
        document.querySelectorAll('.produto .quantidade').forEach(container => {
            const menosBtn = container.querySelector('.menos');
            const maisBtn = container.querySelector('.mais');
            const quantitySpan = container.querySelector('span');

            menosBtn.addEventListener('click', () => {
                const currentQty = parseInt(quantitySpan.textContent);
                if (currentQty > 1) {
                    quantitySpan.textContent = currentQty - 1;
                }
            });

            maisBtn.addEventListener('click', () => {
                const currentQty = parseInt(quantitySpan.textContent);
                quantitySpan.textContent = currentQty + 1;
            });
        });

        // Eventos de adicionar ao carrinho
        document.querySelectorAll('.produto .adicionar').forEach(button => {
            button.addEventListener('click', (event) => {
                const productCard = event.target.closest('.produto');
                this.addToCart(productCard);
            });
        });
    }

    addToCart(productCard) {
        try {
            const name = productCard.querySelector('h2').textContent;
            const price = productCard.querySelector('p').textContent
                .replace('Preço: R$ ', '');
            const quantity = parseInt(productCard.querySelector('.quantidade span').textContent);

            this.cart.addItem({
                name,
                price,
                quantity
            });
        } catch (error) {
            console.error('Erro ao adicionar produto ao carrinho:', error);
            this.cart.showNotification('Erro ao adicionar produto', 'error');
        }
    }
} 