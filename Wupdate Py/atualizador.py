# atualizador.py
import os
import shutil
import time
import json
import datetime
import hashlib
from util import registrar_log

CONFIG_FILE = "config.json"
VERSION_FILE = "version_control.json"

def carregar_config():
    if os.path.exists(CONFIG_FILE):
        with open(CONFIG_FILE, "r") as f:
            return json.load(f)
    return {}

def carregar_versoes():
    """Carrega o controle de versões dos arquivos"""
    if os.path.exists(VERSION_FILE):
        with open(VERSION_FILE, "r") as f:
            return json.load(f)
    return {}

def salvar_versoes(versoes):
    """Salva o controle de versões dos arquivos"""
    with open(VERSION_FILE, "w") as f:
        json.dump(versoes, f, indent=2)

def calcular_hash_arquivo(caminho):
    """Calcula o hash MD5 de um arquivo"""
    try:
        with open(caminho, 'rb') as f:
            return hashlib.md5(f.read()).hexdigest()
    except Exception as e:
        registrar_log(f"ERRO ao calcular hash de {caminho}: {str(e)}")
        return None

def obter_info_arquivo(caminho):
    """Obtém informações do arquivo para controle de versão"""
    try:
        stat = os.stat(caminho)
        return {
            'size': stat.st_size,
            'mtime': stat.st_mtime,
            'hash': calcular_hash_arquivo(caminho)
        }
    except Exception as e:
        registrar_log(f"ERRO ao obter info de {caminho}: {str(e)}")
        return None

def arquivos_para_atualizar(origem, destino):
    arquivos = []
    versoes = carregar_versoes()
    
    for raiz, _, arquivos_encontrados in os.walk(origem):
        for nome_arquivo in arquivos_encontrados:
            caminho_origem = os.path.join(raiz, nome_arquivo)
            caminho_relativo = os.path.relpath(caminho_origem, origem)
            caminho_destino = os.path.join(destino, caminho_relativo)

            precisa_copiar = False
            versao_atual = None
            
            # Verifica se o arquivo existe no destino
            if os.path.exists(caminho_destino):
                # Obtém informações do arquivo de origem
                info_origem = obter_info_arquivo(caminho_origem)
                if info_origem:
                    # Verifica se há mudanças baseadas em hash
                    hash_origem = info_origem['hash']
                    hash_destino = calcular_hash_arquivo(caminho_destino)
                    
                    if hash_origem != hash_destino:
                        precisa_copiar = True
                        versao_atual = info_origem
                        registrar_log(f"Arquivo modificado (hash diferente): {caminho_relativo}")
            else:
                # Arquivo não existe no destino
                precisa_copiar = True
                info_origem = obter_info_arquivo(caminho_origem)
                if info_origem:
                    versao_atual = info_origem
                registrar_log(f"Novo arquivo: {caminho_relativo}")

            if precisa_copiar:
                arquivos.append((caminho_origem, caminho_destino, versao_atual))
    
    return arquivos

def copiar_arquivo_com_retry(origem, destino, max_tentativas=3, delay=1):
    """Copia arquivo com retry automático se estiver em uso"""
    for tentativa in range(max_tentativas):
        try:
            shutil.copy2(origem, destino)
            return True
        except PermissionError:
            if tentativa < max_tentativas - 1:
                registrar_log(f"Arquivo em uso, tentativa {tentativa + 1}/{max_tentativas}: {origem}")
                time.sleep(delay)
            else:
                registrar_log(f"ERRO: Arquivo em uso após {max_tentativas} tentativas: {origem}")
                return False
        except Exception as e:
            registrar_log(f"ERRO ao copiar {origem}: {str(e)}")
            return False
    return False

def copiar_arquivos(arquivos, destino_base):
    data_hoje = datetime.datetime.now().strftime("%Y-%m-%d")
    pasta_backup = os.path.join(destino_base, "__backups__", data_hoje)
    versoes = carregar_versoes()
    arquivos_atualizados = []

    for origem, destino, versao_atual in arquivos:
        # Verifica se já existe o arquivo no destino
        if os.path.exists(destino):
            caminho_relativo = os.path.relpath(destino, destino_base)
            caminho_backup = os.path.join(pasta_backup, caminho_relativo)
            os.makedirs(os.path.dirname(caminho_backup), exist_ok=True)
            if copiar_arquivo_com_retry(destino, caminho_backup):
                registrar_log(f"Backup criado: {caminho_backup}")

        # Agora faz a cópia atualizada
        os.makedirs(os.path.dirname(destino), exist_ok=True)
        if copiar_arquivo_com_retry(origem, destino):
            registrar_log(f"Copiado: {origem} → {destino}")
            
            # Atualiza controle de versão
            if versao_atual:
                caminho_relativo = os.path.relpath(origem, destino_base)
                versoes[caminho_relativo] = {
                    'versao': len(versoes.get(caminho_relativo, {}).get('historico', [])) + 1,
                    'data_atualizacao': datetime.datetime.now().isoformat(),
                    'tamanho': versao_atual['size'],
                    'hash': versao_atual['hash'],
                    'historico': versoes.get(caminho_relativo, {}).get('historico', []) + [{
                        'versao': len(versoes.get(caminho_relativo, {}).get('historico', [])) + 1,
                        'data': datetime.datetime.now().isoformat(),
                        'tamanho': versao_atual['size'],
                        'hash': versao_atual['hash']
                    }]
                }
                arquivos_atualizados.append(caminho_relativo)

    # Salva o controle de versões
    if arquivos_atualizados:
        salvar_versoes(versoes)
        registrar_log(f"Controle de versão atualizado para {len(arquivos_atualizados)} arquivo(s)")

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
