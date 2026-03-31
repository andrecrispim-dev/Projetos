# main_loop.py
import threading
import time
from atualizador import executar_atualizacao
import json
import os

CONFIG_FILE = "config.json"

def carregar_config():
    if os.path.exists(CONFIG_FILE):
        with open(CONFIG_FILE, "r") as f:
            return json.load(f)
    return {}

def iniciar_loop():
    def loop():
        while True:
            config = carregar_config()
            intervalo = config.get("intervalo", 30)  # padrão 30 segundos
            try:
                intervalo = int(intervalo)
            except ValueError:
                intervalo = 5
            executar_atualizacao()
            time.sleep(intervalo)

    t = threading.Thread(target=loop, daemon=True)
    t.start()
