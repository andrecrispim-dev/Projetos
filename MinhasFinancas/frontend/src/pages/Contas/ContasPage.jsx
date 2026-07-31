import React, { useState, useEffect } from 'react';
import { Plus, Wallet, Landmark, CreditCard, PiggyBank, Briefcase, RefreshCw, X } from 'lucide-react';
import api from '../../services/api';
import './ContasPage.css';

// Dicionário de ícones dinâmicos
const iconMap = {
    'Wallet': Wallet,
    'Landmark': Landmark,
    'CreditCard': CreditCard,
    'PiggyBank': PiggyBank,
    'Briefcase': Briefcase
};

const ContasPage = () => {
    const [contas, setContas] = useState([]);
    const [loading, setLoading] = useState(true);
    const [modalAberto, setModalAberto] = useState(false);

    // Form states
    const [formData, setFormData] = useState({
        nome: '',
        categoria_conta: 'Conta Corrente',
        instituicao: '',
        icone: 'Landmark',
        saldo_inicial: '',
        cor_destaque: '#10b981'
    });

    const carregarContas = async () => {
        setLoading(true);
        try {
            const res = await api.get('/contas');
            setContas(res.data);
        } catch (error) {
            console.error('Erro ao buscar contas:', error);
            // Poderíamos adicionar toast/aviso para o usuário
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        carregarContas();
    }, []);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prev => ({ ...prev, [name]: value }));
    };

    const handleSalvarConta = async (e) => {
        e.preventDefault();
        try {
            await api.post('/contas', {
                ...formData,
                saldo_inicial: parseFloat(formData.saldo_inicial || 0)
            });
            setModalAberto(false);
            carregarContas(); // Recarrega a listagem
            
            // Reset do formulário
            setFormData({
                nome: '', categoria_conta: 'Conta Corrente', instituicao: '', icone: 'Landmark', saldo_inicial: '', cor_destaque: '#10b981'
            });
        } catch (error) {
            console.error('Erro ao salvar:', error);
            alert('Falha ao cadastrar a conta bancária.');
        }
    };

    return (
        <div className="contas-page-container">
            <header className="page-header flex-between">
                <div>
                    <h3>Minhas Contas Bancárias</h3>
                    <p>Gerencie seus saldos, instituições e carteiras.</p>
                </div>
                <button className="primary-button" onClick={() => setModalAberto(true)}>
                    <Plus size={18} /> Nova Conta
                </button>
            </header>

            {loading ? (
                <div className="loading-state">
                    <RefreshCw className="spinner" size={30} />
                    <p>Carregando carteiras...</p>
                </div>
            ) : (
                <div className="contas-grid">
                    {contas.length === 0 ? (
                        <div className="empty-state">Você não possui contas cadastradas.</div>
                    ) : (
                        contas.map(conta => {
                            const IconComponent = iconMap[conta.Icone] || Wallet;
                            return (
                                <div className="conta-card" key={conta.Id} style={{ '--border-accent': conta.Cor_Destaque }}>
                                    <div className="conta-icon" style={{ backgroundColor: `${conta.Cor_Destaque}20`, color: conta.Cor_Destaque }}>
                                        <IconComponent size={24} />
                                    </div>
                                    <div className="conta-info">
                                        <h4>{conta.Nome}</h4>
                                        <span className="categoria">{conta.Instituicao ? `${conta.Instituicao} · ` : ''}{conta.Categoria_Conta}</span>
                                    </div>
                                    <div className="conta-saldo">
                                        <span className="saldo-label">Saldo Atual</span>
                                        <span className="saldo-valor">
                                           {new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(conta.Saldo_Atual)}
                                        </span>
                                    </div>
                                </div>
                            );
                        })
                    )}
                </div>
            )}

            {/* Modal de Criação (Glassmorphism Premium) */}
            {modalAberto && (
                <div className="modal-overlay">
                    <div className="modal-content">
                        <header className="modal-header">
                            <h4>Cadastrar Nova Conta</h4>
                            <button className="close-btn" onClick={() => setModalAberto(false)}>
                                <X size={20} />
                            </button>
                        </header>
                        
                        <form onSubmit={handleSalvarConta} className="modal-body">
                            <div className="form-group">
                                <label>Nome da Conta (Ex: NuBank Principal)</label>
                                <input required name="nome" value={formData.nome} onChange={handleChange} placeholder="Digite o nome..." />
                            </div>

                            <div className="form-row">
                                <div className="form-group">
                                    <label>Categoria</label>
                                    <select name="categoria_conta" value={formData.categoria_conta} onChange={handleChange}>
                                        <option>Conta Corrente</option>
                                        <option>Poupança</option>
                                        <option>Carteira (Dinheiro)</option>
                                        <option>Cartão de Crédito</option>
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label>Instituição</label>
                                    <input name="instituicao" value={formData.instituicao} onChange={handleChange} placeholder="Ex: Itaú, Nubank..." />
                                </div>
                            </div>
                            
                            <div className="form-row">
                                <div className="form-group">
                                    <label>Saldo Inicial (R$)</label>
                                    <input type="number" step="0.01" name="saldo_inicial" value={formData.saldo_inicial} onChange={handleChange} placeholder="0.00" />
                                </div>
                                <div className="form-group">
                                    <label>Ícone</label>
                                    <select name="icone" value={formData.icone} onChange={handleChange}>
                                        <option value="Landmark">Banco / Agência</option>
                                        <option value="Wallet">Carteira</option>
                                        <option value="CreditCard">Cartão</option>
                                        <option value="PiggyBank">Cofre</option>
                                    </select>
                                </div>
                                <div className="form-group color-group">
                                    <label>Cor</label>
                                    <input type="color" name="cor_destaque" value={formData.cor_destaque} onChange={handleChange} />
                                </div>
                            </div>

                            <footer className="modal-footer">
                                <button type="button" className="ghost-button" onClick={() => setModalAberto(false)}>Cancelar</button>
                                <button type="submit" className="primary-button">Salvar Conta</button>
                            </footer>
                        </form>
                    </div>
                </div>
            )}
        </div>
    );
};

export default ContasPage;
