import { NavLink } from 'react-router-dom';
import { LayoutDashboard, WalletCards, ArrowRightLeft, PieChart, Settings, LogOut } from 'lucide-react';
import './Sidebar.css';

const Sidebar = () => {
    // Agora o menu utiliza caminhos de verdade no router
    const navItems = [
        { name: 'Dashboard', path: '/', icon: LayoutDashboard },
        { name: 'Contas', path: '/contas', icon: WalletCards }, // A rota que acabamos de criar
        { name: 'Transações', path: '/transacoes', icon: ArrowRightLeft },
        { name: 'Relatórios', path: '/relatorios', icon: PieChart },
        { name: 'Configurações', path: '/configuracoes', icon: Settings }
    ];

    return (
        <aside className="sidebar">
            <div className="sidebar-header">
                <div className="logo-icon">
                    <span className="logo-text-icon">$</span>
                </div>
                <h2>Minhas Finanças</h2>
            </div>

            <nav className="sidebar-nav">
                <ul>
                    {navItems.map((item, index) => {
                        const Icon = item.icon;
                        return (
                            <li key={index}>
                                {/* NavLink aplica classe 'active' automaticamente mediante a rota atual */}
                                <NavLink to={item.path} className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
                                    <Icon size={20} className="nav-icon" />
                                    <span>{item.name}</span>
                                </NavLink>
                            </li>
                        );
                    })}
                </ul>
            </nav>

            <div className="sidebar-footer">
                <a href="#" className="nav-link logout-link">
                    <LogOut size={20} className="nav-icon" />
                    <span>Sair</span>
                </a>
            </div>
        </aside>
    );
};

export default Sidebar;
