import tkinter as tk
from tkinter import filedialog, messagebox
from tkinter import ttk
import json
import os
import sys
import subprocess

CONFIG_FILE = "config.json"


def resource_path(rel_path: str) -> str:
    """Resolve caminho de recursos (funciona no .exe do PyInstaller e no .py)."""
    if hasattr(sys, "_MEIPASS"):
        return os.path.join(sys._MEIPASS, rel_path)
    return os.path.join(os.path.abspath("."), rel_path)

def abrir_no_explorador(caminho: str) -> None:
    """Abre uma pasta/arquivo no explorador conforme o SO."""
    if not caminho:
        return
    if os.path.isdir(caminho) or os.path.isfile(caminho):
        try:
            if sys.platform.startswith("win"):
                os.startfile(caminho)  # type: ignore[attr-defined]
            elif sys.platform == "darwin":
                subprocess.Popen(["open", caminho])
            else:
                subprocess.Popen(["xdg-open", caminho])
        except Exception:
            pass


def salvar_config(config):
    with open(CONFIG_FILE, "w", encoding="utf-8") as f:
        json.dump(config, f, ensure_ascii=False, indent=2)

def carregar_config():
    if os.path.exists(CONFIG_FILE):
        with open(CONFIG_FILE, "r", encoding="utf-8") as f:
            return json.load(f)
    return {}

def iniciar_interface(aba_inicial: str | None = None):
    config = carregar_config()

    root = tk.Tk()
    root.title("WupdateV2 — Configurações")
    root.minsize(700, 380)
    root.geometry("780x420")

    # Ícone da janela (se disponível)
    try:
        root.iconbitmap(default=resource_path("WupdateV2.ico"))
    except Exception:
        pass

    # Tema e estilos (ttk)
    style = ttk.Style()
    try:
        style.theme_use("clam")
    except Exception:
        pass

    style.configure("Accent.TButton", padding=(12, 6), font=("Segoe UI", 10, "bold"))
    style.configure("TButton", padding=(10, 5), font=("Segoe UI", 10))
    style.configure("TLabel", font=("Segoe UI", 10))
    style.configure("Header.TLabel", font=("Segoe UI", 12, "bold"))
    style.configure("Status.TLabel", font=("Segoe UI", 9), foreground="#666")

    # Container principal
    container = ttk.Frame(root, padding=16)
    container.pack(fill="both", expand=True)

    # Cabeçalho
    header = ttk.Frame(container)
    header.pack(fill="x", pady=(0, 8))
    icon_path = resource_path("WupdateV2.ico")
    try:
        from PIL import Image, ImageTk  # type: ignore

        img = Image.open(icon_path)
        img = img.resize((24, 24))
        icon_img = ImageTk.PhotoImage(img)
        icon_label = ttk.Label(header, image=icon_img)
        icon_label.image = icon_img  # keep ref
        icon_label.pack(side="left", padx=(0, 8))
    except Exception:
        pass
    ttk.Label(header, text="WupdateV2", style="Header.TLabel").pack(side="left")

    # Notebook de abas
    notebook = ttk.Notebook(container)
    notebook.pack(fill="both", expand=True)

    # Aba: Configurações
    tab_cfg = ttk.Frame(notebook)
    notebook.add(tab_cfg, text="Configurações")

    # Layout em grid
    tab_cfg.columnconfigure(1, weight=1)

    # Variáveis (tk)
    origem_var = tk.StringVar(value=config.get("origem", ""))
    destino_var = tk.StringVar(value=config.get("destino", ""))
    intervalo_var = tk.StringVar(value=str(config.get("intervalo", 30)))

    # Linha: Origem
    ttk.Label(tab_cfg, text="Pasta de Origem (rede):").grid(row=0, column=0, sticky="e", padx=(0, 8), pady=(8, 4))
    origem_entry = ttk.Entry(tab_cfg, textvariable=origem_var)
    origem_entry.grid(row=0, column=1, sticky="ew", pady=(8, 4))

    origem_btns = ttk.Frame(tab_cfg)
    origem_btns.grid(row=0, column=2, sticky="w", padx=(8, 0), pady=(8, 4))
    ttk.Button(origem_btns, text="Selecionar...", command=lambda: origem_var.set(filedialog.askdirectory() or origem_var.get())).pack(side="left")
    ttk.Button(origem_btns, text="Abrir", command=lambda: abrir_no_explorador(origem_var.get())).pack(side="left", padx=(6, 0))

    # Linha: Destino
    ttk.Label(tab_cfg, text="Pasta de Destino (local):").grid(row=1, column=0, sticky="e", padx=(0, 8), pady=4)
    destino_entry = ttk.Entry(tab_cfg, textvariable=destino_var)
    destino_entry.grid(row=1, column=1, sticky="ew", pady=4)

    destino_btns = ttk.Frame(tab_cfg)
    destino_btns.grid(row=1, column=2, sticky="w", padx=(8, 0), pady=4)
    ttk.Button(destino_btns, text="Selecionar...", command=lambda: destino_var.set(filedialog.askdirectory() or destino_var.get())).pack(side="left")
    ttk.Button(destino_btns, text="Abrir", command=lambda: abrir_no_explorador(destino_var.get())).pack(side="left", padx=(6, 0))

    # Linha: Intervalo
    ttk.Label(tab_cfg, text="Intervalo (segundos):").grid(row=2, column=0, sticky="e", padx=(0, 8), pady=4)
    intervalo_spin = ttk.Spinbox(
        tab_cfg,
        from_=5,
        to=3600,
        increment=5,
        textvariable=intervalo_var,
        width=10,
        justify="center",
    )
    intervalo_spin.grid(row=2, column=1, sticky="w", pady=4)
    ttk.Label(tab_cfg, text="5s a 3600s").grid(row=2, column=2, sticky="w", padx=(8, 0), pady=4)

    # Ações
    ttk.Separator(tab_cfg).grid(row=3, column=0, columnspan=3, sticky="ew", pady=(12, 8))

    botoes = ttk.Frame(tab_cfg)
    botoes.grid(row=4, column=0, columnspan=3, sticky="e")

    status_var = tk.StringVar(value="Configuração carregada.")

    def validar_campos() -> tuple[bool, str]:
        try:
            intervalo = int(intervalo_var.get())
            if intervalo <= 0:
                return False, "O intervalo deve ser maior que zero."
        except ValueError:
            return False, "O intervalo deve ser um número inteiro."

        if not os.path.isdir(origem_var.get()):
            return False, "Pasta de origem inválida."
        if not os.path.isdir(destino_var.get()):
            return False, "Pasta de destino inválida."
        return True, ""

    def salvar(apenas_aplicar: bool = False):
        ok, erro = validar_campos()
        if not ok:
            messagebox.showerror("Erro", erro)
            status_var.set(erro)
            return

        nova_config = {
            "origem": origem_var.get(),
            "destino": destino_var.get(),
            "intervalo": int(intervalo_var.get()),
        }
        salvar_config(nova_config)
        status_var.set("Configuração salva.")
        if not apenas_aplicar:
            messagebox.showinfo("Sucesso", "Configuração salva com sucesso.")
            root.destroy()

    def testar():
        ok, erro = validar_campos()
        if ok:
            messagebox.showinfo("OK", "As configurações parecem válidas.")
            status_var.set("Teste: OK")
        else:
            messagebox.showwarning("Atenção", erro)
            status_var.set(erro)

    ttk.Button(botoes, text="Testar", command=testar).pack(side="left")
    ttk.Button(botoes, text="Aplicar", command=lambda: salvar(True)).pack(side="left", padx=6)
    ttk.Button(botoes, text="Salvar e Fechar", style="Accent.TButton", command=salvar).pack(side="left")

    # Barra de status
    status_bar = ttk.Frame(container)
    status_bar.pack(fill="x", pady=(8, 0))
    ttk.Label(status_bar, textvariable=status_var, style="Status.TLabel").pack(side="left")

    # Aba: Log
    tab_log = ttk.Frame(notebook)
    notebook.add(tab_log, text="Log")

    log_path = "log.txt"
    log_toolbar = ttk.Frame(tab_log)
    log_toolbar.pack(fill="x", pady=(8, 4))

    def carregar_log():
        texto = ""
        if os.path.exists(log_path):
            try:
                with open(log_path, "r", encoding="utf-8", errors="ignore") as f:
                    texto = f.read()[-20000:]  # limita para performance
            except Exception as e:
                texto = f"Erro ao ler log: {e}"
        log_text.configure(state="normal")
        log_text.delete("1.0", tk.END)
        log_text.insert("1.0", texto)
        log_text.configure(state="disabled")

    ttk.Button(log_toolbar, text="Atualizar", command=carregar_log).pack(side="left")
    ttk.Button(log_toolbar, text="Abrir pasta do log", command=lambda: abrir_no_explorador(os.path.dirname(os.path.abspath(log_path)))).pack(side="left", padx=(6, 0))

    log_text = tk.Text(tab_log, height=12, wrap="none", font=("Consolas", 10))
    log_text.pack(fill="both", expand=True)
    carregar_log()

    # Seleção de aba inicial
    if aba_inicial == "log":
        notebook.select(tab_log)

    root.mainloop()
