# app.py
from main_loop import iniciar_loop
from tray import criar_icone

# Inicia o loop de verificação de arquivos em segundo plano
iniciar_loop()

# Roda o ícone na bandeja
criar_icone()
