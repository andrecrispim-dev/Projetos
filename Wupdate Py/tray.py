# tray.py
import pystray
from pystray import MenuItem as item
from PIL import Image, ImageDraw
import threading
from gui import iniciar_interface
import sys
import os
import json
import time
from datetime import datetime
from util import registrar_log

def resource_path(rel_path):
    """Resolve o caminho do recurso tanto no .exe empacotado quanto no .py normal."""
    if hasattr(sys, '_MEIPASS'):
        return os.path.join(sys._MEIPASS, rel_path)
    return os.path.join(os.path.abspath("."), rel_path)

def carregar_config():
    """Carrega a configuração atual"""
    config_file = "config.json"
    if os.path.exists(config_file):
        with open(config_file, "r") as f:
            return json.load(f)
    return {}

def obter_status_sistema():
    """Obtém o status atual do sistema"""
    config = carregar_config()
    if not config.get("origem") or not config.get("destino"):
        return "Não configurado"
    
    try:
        if os.path.exists(config["origem"]) and os.path.exists(config["destino"]):
            return "Ativo"
        else:
            return "Problemas de conectividade"
    except:
        return "Erro de acesso"

def obter_ultima_verificacao():
    """Obtém a última verificação do log"""
    try:
        with open("log.txt", "r", encoding="utf-8") as f:
            linhas = f.readlines()
            if linhas:
                # Pega a última linha que contém verificação
                for linha in reversed(linhas):
                    if "Verificando atualizações" in linha:
                        # Extrai timestamp da linha
                        timestamp = linha.split("]")[0] + "]"
                        return timestamp
        return "Nunca"
    except:
        return "Nunca"

def criar_icone():
    caminho_icone = resource_path("WupdateV2.ico")
    imagem = Image.open(caminho_icone)

    def abrir_config():
        threading.Thread(target=iniciar_interface, daemon=True).start()

    def mostrar_status():
        status = obter_status_sistema()
        ultima = obter_ultima_verificacao()
        config = carregar_config()
        
        msg = f"Status: {status}\n"
        msg += f"Última verificação: {ultima}\n"
        if config.get("origem"):
            msg += f"Origem: {config['origem']}\n"
        if config.get("destino"):
            msg += f"Destino: {config['destino']}\n"
        if config.get("intervalo"):
            msg += f"Intervalo: {config['intervalo']}s"
        
        icone.notify(msg, "Status do WupdateV2")

    def verificar_agora():
        try:
            from atualizador import executar_atualizacao
            executar_atualizacao()
            icone.notify("Verificação manual executada", "WupdateV2")
        except Exception as e:
            icone.notify(f"Erro na verificação: {str(e)}", "WupdateV2")

    def sair():
        icone.notify("WupdateV2 finalizado", "WupdateV2")
        icone.stop()
        sys.exit()

    # Menu com status dinâmico
    status_atual = obter_status_sistema()
    menu = (
        item(f'Status: {status_atual}', mostrar_status),
        item('Verificar agora', verificar_agora),
        item('Abrir Configuração', abrir_config),
        item('Sair', sair)
    )
    
    icone = pystray.Icon("WupdateV2", imagem, "WupdateV2 - Atualizador de Arquivos", menu)
    
    # Notificação inicial
    icone.notify("WupdateV2 iniciado e monitorando arquivos", "WupdateV2")
    
    icone.run()

