import tkinter as tk
from tkinter import filedialog, messagebox
import json
import os
import threading
import time
from datetime import datetime

CONFIG_FILE = "config.json"

def salvar_config(config):
    with open(CONFIG_FILE, "w") as f:
        json.dump(config, f)

def carregar_config():
    if os.path.exists(CONFIG_FILE):
        with open(CONFIG_FILE, "r") as f:
            return json.load(f)
    return {}

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

def testar_conectividade(caminho):
    """Testa se o caminho está acessível"""
    try:
        if os.path.exists(caminho):
            # Testa se consegue listar o diretório
            os.listdir(caminho)
            return True, "Conectividade OK"
        else:
            return False, "Caminho não existe"
    except PermissionError:
        return False, "Sem permissão de acesso"
    except Exception as e:
        return False, f"Erro de conectividade: {str(e)}"

def validar_caminho(caminho):
    """Valida se o caminho é válido"""
    if not caminho:
        return False, "Caminho vazio"
    
    if not os.path.isdir(caminho):
        return False, "Não é um diretório válido"
    
    return True, "Caminho válido"

def iniciar_interface():
    config = carregar_config()

    root = tk.Tk()
    root.title("Configuração do WupdateV2")
    root.geometry("600x300")
    root.resizable(False, False)
    
    # Define o ícone da janela
    try:
        root.iconbitmap("WupdateV2.ico")
    except:
        pass  # Se não conseguir carregar o ícone, continua sem ele

    # Centraliza os elementos com padding
    frame = tk.Frame(root, padx=20, pady=20)
    frame.pack(fill="both", expand=True)

    # Variáveis
    origem_var = tk.StringVar(value=config.get("origem", ""))
    destino_var = tk.StringVar(value=config.get("destino", ""))
    intervalo_var = tk.StringVar(value=str(config.get("intervalo", 30)))

    # Labels de status
    status_origem = tk.StringVar(value="")
    status_destino = tk.StringVar(value="")
    status_conectividade = tk.StringVar(value="")
    status_sistema = tk.StringVar(value="Sistema: Aguardando configuração...")
    ultima_verificacao = tk.StringVar(value="")

    # Função para atualizar última verificação
    def atualizar_ultima_verificacao():
        ultima = obter_ultima_verificacao()
        ultima_verificacao.set(f"Última verificação: {ultima}")
        # Agenda próxima atualização em 5 segundos
        root.after(5000, atualizar_ultima_verificacao)

    # Linha 1 – Pasta de origem
    tk.Label(frame, text="Pasta de Origem (rede):").grid(row=0, column=0, sticky="e")
    origem_entry = tk.Entry(frame, textvariable=origem_var, width=45)
    origem_entry.grid(row=0, column=1, padx=5)
    tk.Button(frame, text="Selecionar...", command=lambda: origem_var.set(filedialog.askdirectory())).grid(row=0, column=2)
    
    # Status da origem
    tk.Label(frame, textvariable=status_origem, fg="blue").grid(row=0, column=3, padx=10)

    # Linha 2 – Pasta de destino
    tk.Label(frame, text="Pasta de Destino (local):").grid(row=1, column=0, sticky="e", pady=10)
    destino_entry = tk.Entry(frame, textvariable=destino_var, width=45)
    destino_entry.grid(row=1, column=1, padx=5, pady=10)
    tk.Button(frame, text="Selecionar...", command=lambda: destino_var.set(filedialog.askdirectory())).grid(row=1, column=2)
    
    # Status do destino
    tk.Label(frame, textvariable=status_destino, fg="blue").grid(row=1, column=3, padx=10)

    # Linha 3 – Intervalo
    tk.Label(frame, text="Intervalo (segundos):").grid(row=2, column=0, sticky="e")
    intervalo_entry = tk.Entry(frame, textvariable=intervalo_var, width=10)
    intervalo_entry.grid(row=2, column=1, sticky="w")

    # Linha 4 – Botão de teste de conectividade
    def testar_conectividade_btn():
        origem = origem_var.get()
        destino = destino_var.get()
        
        if not origem or not destino:
            messagebox.showwarning("Aviso", "Preencha ambos os caminhos antes de testar.")
            return
        
        # Testa origem
        ok_origem, msg_origem = testar_conectividade(origem)
        status_origem.set("✓" if ok_origem else "✗")
        
        # Testa destino
        ok_destino, msg_destino = testar_conectividade(destino)
        status_destino.set("✓" if ok_destino else "✗")
        
        # Resultado geral
        if ok_origem and ok_destino:
            status_conectividade.set("Conectividade: OK")
            status_sistema.set("Sistema: Pronto para operação")
            messagebox.showinfo("Teste de Conectividade", "Ambos os caminhos estão acessíveis!")
        else:
            status_conectividade.set("Conectividade: PROBLEMAS")
            status_sistema.set("Sistema: Problemas de conectividade")
            messagebox.showerror("Teste de Conectividade", 
                               f"Problemas encontrados:\nOrigem: {msg_origem}\nDestino: {msg_destino}")

    testar_btn = tk.Button(frame, text="🔍 Testar Conectividade", bg="#2196F3", fg="white", 
                          font=("Segoe UI", 9, "bold"), command=testar_conectividade_btn)
    testar_btn.grid(row=2, column=2, columnspan=2, pady=5)

    # Status de conectividade
    tk.Label(frame, textvariable=status_conectividade, fg="green", font=("Segoe UI", 9, "bold")).grid(row=3, column=0, columnspan=4, pady=5)

    # Linha 5 – Status do sistema em tempo real
    tk.Label(frame, textvariable=status_sistema, fg="purple", font=("Segoe UI", 10, "bold")).grid(row=4, column=0, columnspan=4, pady=5)
    tk.Label(frame, textvariable=ultima_verificacao, fg="gray", font=("Segoe UI", 8)).grid(row=5, column=0, columnspan=4, pady=2)

    # Função de validação em tempo real
    def validar_caminhos(*args):
        origem = origem_var.get()
        destino = destino_var.get()
        
        # Valida origem
        if origem:
            ok, msg = validar_caminho(origem)
            if ok:
                status_origem.set("✓ Válido")
            else:
                status_origem.set("✗ Inválido")
        else:
            status_origem.set("")
        
        # Valida destino
        if destino:
            ok, msg = validar_caminho(destino)
            if ok:
                status_destino.set("✓ Válido")
            else:
                status_destino.set("✗ Inválido")
        else:
            status_destino.set("")

        # Atualiza status do sistema
        if origem and destino:
            ok_origem, _ = validar_caminho(origem)
            ok_destino, _ = validar_caminho(destino)
            if ok_origem and ok_destino:
                status_sistema.set("Sistema: Configurado e pronto")
            else:
                status_sistema.set("Sistema: Configuração incompleta")
        else:
            status_sistema.set("Sistema: Aguardando configuração...")

    # Bind das validações
    origem_var.trace('w', validar_caminhos)
    destino_var.trace('w', validar_caminhos)

    # Linha 6 – Botão salvar
    def salvar():
        try:
            intervalo = int(intervalo_var.get())
            if intervalo <= 0:
                raise ValueError
        except ValueError:
            messagebox.showerror("Erro", "O intervalo deve ser um número inteiro maior que zero.")
            return

        nova_config = {
            "origem": origem_var.get(),
            "destino": destino_var.get(),
            "intervalo": intervalo
        }

        if not os.path.isdir(nova_config["origem"]) or not os.path.isdir(nova_config["destino"]):
            messagebox.showerror("Erro", "Por favor selecione pastas válidas.")
            return

        salvar_config(nova_config)
        status_sistema.set("Sistema: Configuração salva com sucesso")
        messagebox.showinfo("Sucesso", "Configuração salva com sucesso.")
        root.destroy()

    salvar_btn = tk.Button(frame, text="💾 Salvar Configuração", bg="#4CAF50", fg="white", font=("Segoe UI", 10, "bold"), command=salvar)
    salvar_btn.grid(row=6, column=0, columnspan=4, pady=20)

    # Executa validação inicial
    validar_caminhos()
    
    # Inicia atualização da última verificação
    atualizar_ultima_verificacao()

    root.mainloop()
