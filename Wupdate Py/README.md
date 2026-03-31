# WupdateV2 - Atualizador de Arquivos

Sistema de sincronização automática de arquivos entre pastas de origem (rede) e destino (local).

## Funcionalidades Implementadas

### ✅ Melhorias Recentes

1. **Sistema de Logging Aprimorado**
   - Timestamp com milissegundos para maior precisão
   - Logs detalhados de todas as operações

2. **Tratamento de Erros Robusto**
   - Retry automático para arquivos em uso
   - Logs específicos para problemas de permissão
   - Tratamento de exceções em operações críticas

3. **Validação em Tempo Real**
   - Verificação de conectividade de rede
   - Validação de caminhos em tempo real
   - Teste de conectividade integrado

4. **Interface Gráfica Melhorada**
   - Indicador de status em tempo real
   - Botão de teste de conectividade
   - Validação visual dos campos
   - Feedback visual do estado do sistema

5. **Sistema de Tray Aprimorado**
   - Notificações do sistema
   - Menu de status dinâmico
   - Verificação manual de arquivos
   - Feedback visual melhorado

6. **Controle de Versão de Arquivos**
   - Hash MD5 para verificação de integridade
   - Histórico de versões dos arquivos
   - Detecção de mudanças baseada em hash
   - Registro de todas as atualizações

## Instalação

1. Instale as dependências:
```bash
pip install -r requirements.txt
```

2. Execute o aplicativo:
```bash
python app.py
```

## Configuração

1. Clique com o botão direito no ícone da bandeja
2. Selecione "Abrir Configuração"
3. Configure as pastas de origem e destino
4. Defina o intervalo de verificação
5. Teste a conectividade
6. Salve a configuração

## Funcionalidades

- **Sincronização Automática**: Monitora mudanças na pasta de origem
- **Backup Automático**: Cria backups antes de atualizar arquivos
- **Controle de Versão**: Mantém histórico de todas as versões
- **Retry Automático**: Tenta novamente se arquivo estiver em uso
- **Logs Detalhados**: Registra todas as operações com timestamp preciso
- **Interface Intuitiva**: GUI amigável com validação em tempo real
- **Notificações**: Sistema de notificações para status e eventos

## Arquivos do Sistema

- `app.py` - Arquivo principal
- `atualizador.py` - Lógica de sincronização
- `gui.py` - Interface gráfica
- `tray.py` - Sistema de bandeja
- `main_loop.py` - Loop principal
- `util.py` - Utilitários e logging
- `config.json` - Configurações
- `version_control.json` - Controle de versões
- `log.txt` - Logs do sistema

## Logs

O sistema gera logs detalhados com:
- Timestamp com milissegundos
- Operações de cópia e backup
- Tentativas de retry para arquivos em uso
- Controle de versão de arquivos
- Status de conectividade

## Controle de Versão

O sistema mantém um arquivo `version_control.json` que registra:
- Hash MD5 de cada arquivo
- Histórico de versões
- Data e hora das atualizações
- Tamanho dos arquivos

## Notificações

O sistema envia notificações para:
- Início do aplicativo
- Problemas de conectividade
- Verificações manuais
- Finalização do aplicativo
