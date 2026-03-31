export class Cart {
    constructor() {
        this.items = this.loadCart();
        this.listeners = [];
    }

    loadCart() {
        try {
            const savedCart = localStorage.getItem('cart');
            return savedCart ? JSON.parse(savedCart) : [];
        } catch (error) {
            console.error('Erro ao carregar carrinho:', error);
            return [];
        }
    }

    saveCart() {
        try {
            localStorage.setItem('cart', JSON.stringify(this.items));
            this.notifyListeners();
        } catch (error) {
            console.error('Erro ao salvar carrinho:', error);
            this.showNotification('Erro ao salvar carrinho', 'error');
        }
    }

    addItem(product) {
        try {
            const existingItem = this.items.find(item => item.name === product.name);

            if (existingItem) {
                existingItem.quantity += product.quantity;
            } else {
                this.items.push(product);
            }

            this.saveCart();
            this.showNotification('Produto adicionado ao carrinho!', 'success');
        } catch (error) {
            console.error('Erro ao adicionar item:', error);
            this.showNotification('Erro ao adicionar item', 'error');
        }
    }

    removeItem(productName) {
        try {
            this.items = this.items.filter(item => item.name !== productName);
            this.saveCart();
            this.showNotification('Produto removido do carrinho!', 'success');
        } catch (error) {
            console.error('Erro ao remover item:', error);
            this.showNotification('Erro ao remover item', 'error');
        }
    }

    updateQuantity(productName, newQuantity) {
        try {
            const item = this.items.find(item => item.name === productName);
            if (item) {
                item.quantity = Math.max(1, newQuantity);
                this.saveCart();
            }
        } catch (error) {
            console.error('Erro ao atualizar quantidade:', error);
            this.showNotification('Erro ao atualizar quantidade', 'error');
        }
    }

    getTotal() {
        return this.items.reduce((total, item) => {
            const price = parseFloat(item.price.replace(',', '.'));
            return total + (price * item.quantity);
        }, 0).toFixed(2);
    }

    clear() {
        this.items = [];
        this.saveCart();
    }

    addListener(callback) {
        this.listeners.push(callback);
    }

    notifyListeners() {
        this.listeners.forEach(callback => callback(this.items));
    }

    showNotification(message, type = 'info') {
        const notification = document.createElement('div');
        notification.className = `notification ${type}`;
        notification.textContent = message;

        // Adiciona a notificação ao DOM
        document.body.appendChild(notification);

        // Remove após 3 segundos
        setTimeout(() => {
            notification.remove();
        }, 3000);
    }
} 