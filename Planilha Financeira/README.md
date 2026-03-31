# 💰 Planilha Financeira Pessoal

Uma aplicação web completa para controle financeiro pessoal, desenvolvida em HTML, CSS e JavaScript puro.

## 🚀 Funcionalidades

### 📈 Gestão de Entradas
- Adicionar diferentes tipos de entradas (Salário, Horas Extras, Bônus, etc.)
- Histórico completo de entradas
- Edição e exclusão de registros

### 📉 Gestão de Saídas
- Categorização por tipo (Despesa Fixa, Cartão de Crédito, Despesa Esporádica)
- Subcategorias específicas para cada tipo
- Controle detalhado de gastos

### 📊 Resumo e Análises
- Resumo mensal com filtros por período
- Cards visuais com totais de entradas, saídas e saldo
- Análise por categoria com percentuais

### 📋 Gráficos Interativos
- Gráfico de barras: Entradas vs Saídas por mês
- Gráfico de pizza: Distribuição de gastos por categoria
- Gráfico de linha: Evolução do saldo acumulado

### 💾 Exportação de Dados
- Exportação em formato CSV
- Exportação em formato JSON
- Relatório para impressão
- Backup automático no navegador (localStorage)

## 🛠️ Tecnologias Utilizadas

- **HTML5**: Estrutura semântica e responsiva
- **CSS3**: Design moderno com gradientes e animações
- **JavaScript ES6+**: Lógica da aplicação
- **Chart.js**: Gráficos interativos
- **LocalStorage**: Armazenamento local dos dados

## 📱 Responsividade

A aplicação é totalmente responsiva e funciona perfeitamente em:
- Desktop
- Tablet
- Smartphone

## 🎨 Design

- Interface moderna e intuitiva
- Cores harmoniosas e profissionais
- Animações suaves
- Feedback visual para todas as ações
- Notificações em tempo real

## 🚀 Como Usar

### Instalação
1. Clone ou baixe os arquivos
2. Abra o arquivo `index.html` em qualquer navegador moderno
3. Ou execute um servidor local:
   ```bash
   python -m http.server 8000
   ```
   E acesse `http://localhost:8000`

### Primeiros Passos
1. **Adicionar Entradas**: Vá para a aba "Entradas" e preencha os dados
2. **Adicionar Saídas**: Vá para a aba "Saídas", selecione o tipo e categoria
3. **Visualizar Resumo**: A aba "Resumo" mostra os totais e análises
4. **Analisar Gráficos**: A aba "Gráficos" oferece visualizações interativas

### Funcionalidades Avançadas
- **Filtros**: Use o filtro de mês/ano para analisar períodos específicos
- **Exportação**: Exporte seus dados em CSV ou JSON
- **Impressão**: Gere relatórios para impressão
- **Backup**: Os dados são salvos automaticamente no navegador

## 📊 Categorias Disponíveis

### Entradas
- Salário
- Horas Extras
- Bônus
- Férias
- 13º Salário
- Freelance
- Investimentos
- Outros

### Saídas por Tipo

#### Despesa Fixa
- Habitação
- Transporte
- Seguros
- Educação
- Saúde
- Outros

#### Cartão de Crédito
- Alimentação
- Compras
- Entretenimento
- Saúde
- Transporte
- Educação
- Outros

#### Despesa Esporádica
- Alimentação
- Transporte
- Entretenimento
- Presentes
- Saúde
- Educação
- Outros

## 🔧 Recursos Técnicos

### Validações
- Campos obrigatórios
- Valores numéricos válidos
- Datas válidas
- Feedback de erros

### Performance
- Carregamento rápido
- Otimização de memória
- Destruição adequada de gráficos

### Segurança
- Validação de entrada
- Sanitização de dados
- Tratamento de erros

## 🐛 Correções Implementadas

### Problemas Corrigidos
1. **Script não carregado**: Adicionada tag de fechamento `</script>`
2. **Função showTab**: Corrigido parâmetro `event` não definido
3. **Inicialização**: Melhorada a inicialização com verificações de segurança
4. **Validações**: Adicionadas validações robustas para todos os campos
5. **Tratamento de Erros**: Implementado try-catch em todas as funções críticas
6. **Feedback Visual**: Adicionadas notificações para todas as ações
7. **Responsividade**: Melhorada a experiência em dispositivos móveis

### Melhorias Adicionadas
- Sistema de notificações em tempo real
- IDs únicos mais robustos
- Verificação de elementos DOM antes de uso
- Melhor tratamento de dados vazios
- Animações CSS para melhor UX
- Botão para limpar todos os dados
- Verificação de dependências (Chart.js)

## 📈 Próximas Funcionalidades

- [ ] Importação de dados CSV/JSON
- [ ] Múltiplas contas/carteiras
- [ ] Metas financeiras
- [ ] Alertas de orçamento
- [ ] Sincronização em nuvem
- [ ] Relatórios avançados
- [ ] Dashboard personalizado

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para:
- Reportar bugs
- Sugerir novas funcionalidades
- Melhorar o código
- Adicionar documentação

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 👨‍💻 Autor

Desenvolvido com ❤️ para controle financeiro pessoal.

---

**Versão**: 2.0.0  
**Última atualização**: Dezembro 2024
