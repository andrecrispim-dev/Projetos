param(
    [Parameter(Mandatory = $false)]
    [string]$Pasta = "."
)

$ErrorActionPreference = "Stop"

if (-not (Test-Path -LiteralPath $Pasta -PathType Container)) {
    throw "A pasta informada nao existe: $Pasta"
}

# Padrao esperado: TabelaIBPTax + UF(2 letras) + versao (ex: 26.1.F) + .csv
$padrao = '^TabelaIBPTax(?<UF>[A-Z]{2})(?<VERSAO>\d+\.\d+\.[A-Z])\.csv$'

$arquivos = Get-ChildItem -LiteralPath $Pasta -File -Filter "*.csv"
$renomeados = 0
$versaoAtual = $null

foreach ($arquivo in $arquivos) {
    $match = [regex]::Match($arquivo.Name, $padrao)
    if (-not $match.Success) {
        continue
    }

    $uf = $match.Groups['UF'].Value
    $versao = $match.Groups['VERSAO'].Value
    $novoNome = "$uf.csv"
    $novoCaminho = Join-Path -Path $arquivo.DirectoryName -ChildPath $novoNome

    if ($arquivo.FullName -ieq $novoCaminho) {
        # Ja esta com nome final
        $versaoAtual = $versao
        continue
    }

    if (Test-Path -LiteralPath $novoCaminho) {
        throw "Ja existe um arquivo com o nome destino: $novoNome"
    }

    Rename-Item -LiteralPath $arquivo.FullName -NewName $novoNome
    $renomeados++
    $versaoAtual = $versao
}

if ($null -ne $versaoAtual) {
    $arquivoVersao = Join-Path -Path $Pasta -ChildPath "versaoIBPT_Atual.txt"
    Set-Content -LiteralPath $arquivoVersao -Value $versaoAtual -Encoding UTF8
    Write-Host "Arquivo de versao criado/atualizado: $arquivoVersao"
}
else {
    Write-Host "Nenhum arquivo no padrao IBPT foi encontrado para processar."
}

# Cria uma copia de qualquer CSV da pasta com o nome Atualiza.csv.
$origemAtualiza = Get-ChildItem -LiteralPath $Pasta -File -Filter "*.csv" |
    Where-Object { $_.Name -ine "Atualiza.csv" } |
    Select-Object -First 1

if ($null -ne $origemAtualiza) {
    $arquivoAtualiza = Join-Path -Path $Pasta -ChildPath "Atualiza.csv"
    Copy-Item -LiteralPath $origemAtualiza.FullName -Destination $arquivoAtualiza -Force
    Write-Host "Copia criada/atualizada: $arquivoAtualiza (origem: $($origemAtualiza.Name))"
}
else {
    Write-Host "Nenhum CSV disponivel para criar Atualiza.csv"
}

Write-Host "Total de arquivos renomeados: $renomeados"
