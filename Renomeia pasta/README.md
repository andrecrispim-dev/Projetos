# Renomeador IBPT

Este script renomeia arquivos no formato:

`TabelaIBPTaxUF26.1.F.csv`

para:

`UF.csv`

Tambem cria/atualiza o arquivo `versaoIBPT_Atual.txt` com a versao encontrada no nome do arquivo (ex.: `26.1.F`).

Tambem cria/atualiza `Atualiza.csv` como copia de um dos arquivos `.csv` existentes na pasta.

## Como usar

No PowerShell, dentro da pasta do projeto:

```powershell
.\renomear_ibpt.ps1 -Pasta "C:\caminho\da\sua\pasta"
```

Se omitir `-Pasta`, o script usa a pasta atual.

```powershell
.\renomear_ibpt.ps1
```

## Exportar XMLs (versao PowerShell)

Script equivalente ao `Exportar XMLs.py`, agora em PowerShell: `Exportar XMLs.ps1`.

Exemplo sem perguntas interativas:

```powershell
.\Exportar XMLs.ps1 -CaminhoBaseOrigem "D:\origem" -Ano 2023 -Mes 1 -NomePastaDestino "XMLs_2023_01" -NaoPerguntarCaminhoOrigem
```

Sem parametros, ele pergunta ano, mes e pasta de destino no terminal.
