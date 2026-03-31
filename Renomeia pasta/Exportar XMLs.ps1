param(
    [string]$CaminhoBaseOrigem = 'E:\Winexus\NFCE\WinNFCeServer.xml\CNPJ10860783000137\MD65\AMB01',
    [string]$Ano,
    [string]$Mes,
    [string]$NomePastaDestino,
    [switch]$NaoPerguntarCaminhoOrigem
)

$ErrorActionPreference = 'Stop'

function Copiar-XMLs {
    param(
        [string]$OrigemBase,
        [string]$AnoInformado,
        [string]$MesInformado,
        [string]$DestinoNome,
        [switch]$SemPerguntaOrigem
    )

    if (-not $SemPerguntaOrigem) {
        $alterarCaminho = (Read-Host "O caminho de origem padrao e:`n$OrigemBase`nDeseja alterar? (s/n)").ToLower()
        if ($alterarCaminho -eq 's') {
            $novoCaminho = Read-Host 'Por favor, digite o novo caminho de origem'
            if (-not [string]::IsNullOrWhiteSpace($novoCaminho)) {
                $OrigemBase = $novoCaminho
            }
        }
    }

    if ([string]::IsNullOrWhiteSpace($AnoInformado)) {
        $AnoInformado = Read-Host 'Digite o ano que deseja buscar (ex: 2023)'
    }

    if ([string]::IsNullOrWhiteSpace($MesInformado)) {
        $MesInformado = Read-Host 'Digite o mes que deseja buscar (ex: 01, 02, 10)'
    }
    $MesInformado = $MesInformado.PadLeft(2, '0')

    if ([string]::IsNullOrWhiteSpace($DestinoNome)) {
        $DestinoNome = Read-Host 'Digite o nome da nova pasta de destino'
    }

    $caminhoDestino = Join-Path -Path (Get-Location) -ChildPath $DestinoNome

    if (-not (Test-Path -LiteralPath $caminhoDestino -PathType Container)) {
        New-Item -ItemType Directory -Path $caminhoDestino | Out-Null
        Write-Host "`n---"
        Write-Host "Pasta de destino '$DestinoNome' criada em: $caminhoDestino"
    }
    else {
        Write-Host "`n---"
        Write-Host "Pasta de destino '$DestinoNome' ja existe."
    }

    $caminhoMes = Join-Path -Path $OrigemBase -ChildPath (Join-Path -Path "ANO$AnoInformado" -ChildPath "MES$MesInformado")

    if (-not (Test-Path -LiteralPath $caminhoMes -PathType Container)) {
        Write-Host "Erro: O caminho para o mes especificado nao foi encontrado: $caminhoMes"
        return
    }

    Write-Host "Iniciando a busca por arquivos XML em: $caminhoMes"

    $arquivosCopiados = 0

    Get-ChildItem -LiteralPath $caminhoMes -Recurse -File | Where-Object {
        $_.Directory.Name -ieq 'NFE' -and $_.Extension -ieq '.xml'
    } | ForEach-Object {
        $origemArquivo = $_.FullName
        $destinoArquivo = Join-Path -Path $caminhoDestino -ChildPath $_.Name

        try {
            Copy-Item -LiteralPath $origemArquivo -Destination $destinoArquivo -Force
            Write-Host "Copiado: $($_.Name)"
            $arquivosCopiados++
        }
        catch {
            Write-Host "Erro ao copiar o arquivo $($_.Name): $($_.Exception.Message)"
        }
    }

    Write-Host "`n---"
    Write-Host "Processo concluido. $arquivosCopiados arquivo(s) XML copiado(s) para a pasta '$DestinoNome'."
}

Copiar-XMLs -OrigemBase $CaminhoBaseOrigem -AnoInformado $Ano -MesInformado $Mes -DestinoNome $NomePastaDestino -SemPerguntaOrigem:$NaoPerguntarCaminhoOrigem
