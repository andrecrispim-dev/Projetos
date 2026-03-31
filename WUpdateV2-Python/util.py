# util.py
import time
import os

LOG_FILE = "log.txt"

def registrar_log(mensagem):
    timestamp = time.strftime("[%Y-%m-%d %H:%M:%S]")
    texto = f"{timestamp} {mensagem}"
    print(texto)
    with open(LOG_FILE, "a", encoding="utf-8") as f:
        f.write(texto + "\n")
