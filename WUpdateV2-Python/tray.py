# tray.py
import pystray
from pystray import MenuItem as item
from PIL import Image, ImageDraw
import threading
from gui import iniciar_interface
import sys
import os

def resource_path(rel_path):
    """Resolve o caminho do recurso tanto no .exe empacotado quanto no .py normal."""
    if hasattr(sys, '_MEIPASS'):
        return os.path.join(sys._MEIPASS, rel_path)
    return os.path.join(os.path.abspath("."), rel_path)

def criar_icone():
    caminho_icone = resource_path("WupdateV2.ico")
    imagem = Image.open(caminho_icone)

    def abrir_config():
        threading.Thread(target=iniciar_interface, kwargs={"aba_inicial": None}, daemon=True).start()

    def abrir_log():
        threading.Thread(target=iniciar_interface, kwargs={"aba_inicial": "log"}, daemon=True).start()

    def sair():
        icone.stop()
        sys.exit()

    menu = (
        item('Abrir Configuração', abrir_config),
        item('Abrir Log', abrir_log),
        item('Sair', sair),
    )
    icone = pystray.Icon("WupdateV2", imagem, "WupdateV2", menu)
    icone.run()

