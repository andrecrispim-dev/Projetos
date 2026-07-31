import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './components/layout/Layout';
import ContasPage from './pages/Contas/ContasPage';
import './App.css';

// Componente simulando a Dashboard Inicial que fizemos antes
const Dashboard = () => (
    <div className="dashboard-placeholder">
        <header className="page-header">
           <h3>Visão Geral do Dashboard</h3>
           <p>Resumo financeiro geral do sistema.</p>
        </header>
        
        <div className="metrics-grid">
            <div className="metric-card">
                <span className="metric-title">Saldo Total</span>
                <span className="metric-value positive">R$ 15.430,00</span>
            </div>
            <div className="metric-card pattern-bg">
                <span className="metric-title">Despesas (Mês)</span>
                <span className="metric-value negative">R$ -3.200,00</span>
            </div>
            <div className="metric-card">
                <span className="metric-title">Faturas Abertas</span>
                <span className="metric-value">R$ 1.150,00</span>
            </div>
        </div>
    </div>
);

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/contas" element={<ContasPage />} />
            {/* Futuras rotas entram aqui */}
        </Routes>
      </Layout>
    </BrowserRouter>
  )
}

export default App;
