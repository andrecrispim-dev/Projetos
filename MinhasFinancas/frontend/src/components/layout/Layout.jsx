import Sidebar from './Sidebar';
import './Layout.css';

// Componente Wrapper (Contêiner) de todas as páginas da aplicação
const Layout = ({ children }) => {
    return (
        <div className="layout-container">
            <Sidebar />
            
            <main className="layout-main">
                <header className="topbar">
                    <div className="topbar-left">
                        <h2>Bem Vindo de Volta 👋</h2>
                    </div>
                    <div className="topbar-right">
                        <div className="user-profile">
                            <span className="user-name">Usuário</span>
                            <div className="avatar">A</div>
                        </div>
                    </div>
                </header>
                
                <section className="layout-content">
                    {children}
                </section>
            </main>
        </div>
    );
};

export default Layout;
