# atualizador.py
import os
import shutil
import time
import json
import datetime
from util import registrar_log

CONFIG_FILE = "config.json"

def carregar_config():
    if os.path.exists(CONFIG_FILE):
        with open(CONFIG_FILE, "r") as f:
            return json.load(f)
    return {}

def arquivos_para_atualizar(origem, destino):
    arquivos = []
    for raiz, _, arquivos_encontrados in os.walk(origem):
        for nome_arquivo in arquivos_encontrados:
            caminho_origem = os.path.join(raiz, nome_arquivo)
            caminho_relativo = os.path.relpath(caminho_origem, origem)
            caminho_destino = os.path.join(destino, caminho_relativo)

            precisa_copiar = False
            if not os.path.exists(caminho_destino):
                precisa_copiar = True
            else:
                mtime_origem = os.path.getmtime(caminho_origem)
                mtime_destino = os.path.getmtime(caminho_destino)
                if mtime_origem > mtime_destino:
                    precisa_copiar = True

            if precisa_copiar:
                arquivos.append((caminho_origem, caminho_destino))
    return arquivos

def copiar_arquivos(arquivos, destino_base):
    data_hoje = datetime.datetime.now().strftime("%Y-%m-%d")
    pasta_backup = os.path.join(destino_base, "__backups__", data_hoje)

    for origem, destino in arquivos:
        # Verifica se já existe o arquivo no destino
        if os.path.exists(destino):
            caminho_relativo = os.path.relpath(destino, destino_base)
            caminho_backup = os.path.join(pasta_backup, caminho_relativo)
            os.makedirs(os.path.dirname(caminho_backup), exist_ok=True)
            shutil.copy2(destino, caminho_backup)
            registrar_log(f"Backup criado: {caminho_backup}")

        # Agora faz a cópia atualizada
        os.makedirs(os.path.dirname(destino), exist_ok=True)
        shutil.copy2(origem, destino)
        registrar_log(f"Copiado: {origem} → {destino}")

def executar_atualizacao():
    config = carregar_config()
    origem = config.get("origem")
    destino = config.get("destino")

    if not origem or not destino:
        registrar_log("Configuração incompleta.")
        return

    arquivos = arquivos_para_atualizar(origem, destino)
    if arquivos:
        registrar_log("Verificando atualizações...")
        registrar_log(f"{len(arquivos)} arquivo(s) serão atualizados.")
        copiar_arquivos(arquivos, destino)
#    else:
#        registrar_log("Nenhum arquivo novo ou atualizado encontrado.")
