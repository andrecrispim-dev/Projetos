import os
import shutil

def copiar_xmls():
    """
    Esta função pede ao usuário por um ano e mês, 
    busca por arquivos XML em subpastas 'NFE' e os copia 
    para uma nova pasta de destino criada pelo usuário.
    """
    # Caminho de origem padrão. O 'r' trata a string como "raw"
    caminho_base_origem = r'C:\Winexus\NFCE\WinNFCeServer.xml\CNPJ44343055000170\MD65\AMB01'
    
    # Pergunta ao usuário se ele quer alterar o caminho de origem
    alterar_caminho = input(f"O caminho de origem padrão é:\n{caminho_base_origem}\nDeseja alterar? (s/n): ").lower()
    
    if alterar_caminho == 's':
        caminho_base_origem = input("Por favor, digite o novo caminho de origem: ")

    # Pega o ano do usuário
    ano_desejado = input("Digite o ano que deseja buscar (ex: 2023): ")
    
    # Pega o mês do usuário e formata para 2 dígitos (ex: '1' vira '01')
    mes_desejado = input("Digite o mês que deseja buscar (ex: 01, 02, 10): ").zfill(2)

    # Pede para o usuário digitar o nome da pasta de destino e a cria
    nome_pasta_destino = input("Digite o nome da nova pasta de destino: ")
    
    # Cria a pasta de destino no diretório atual do script
    caminho_destino = os.path.join(os.getcwd(), nome_pasta_destino)
    
    if not os.path.exists(caminho_destino):
        os.makedirs(caminho_destino)
        print(f"\n---")
        print(f"Pasta de destino '{nome_pasta_destino}' criada em: {caminho_destino}")
    else:
        print(f"\n---")
        print(f"Pasta de destino '{nome_pasta_destino}' já existe.")

    # Monta o caminho completo até a pasta do mês
    caminho_mes = os.path.join(caminho_base_origem, f'ANO{ano_desejado}', f'MES{mes_desejado}')

    if not os.path.exists(caminho_mes):
        print(f"Erro: O caminho para o mês especificado não foi encontrado: {caminho_mes}")
        return

    print(f"Iniciando a busca por arquivos XML em: {caminho_mes}")
    
    arquivos_copiados = 0

    # Itera sobre todas as pastas e arquivos a partir do caminho do mês
    for raiz, pastas, arquivos in os.walk(caminho_mes):
        # Verifica se o nome da pasta atual é 'NFE'
        if os.path.basename(raiz).upper() == 'NFE':
            # Itera sobre os arquivos dentro da pasta 'NFE'
            for arquivo in arquivos:
                # Verifica se o arquivo é um .xml (ignorando maiúsculas/minúsculas)
                if arquivo.lower().endswith('.xml'):
                    caminho_arquivo_origem = os.path.join(raiz, arquivo)
                    caminho_arquivo_destino = os.path.join(caminho_destino, arquivo)
                    
                    try:
                        shutil.copy2(caminho_arquivo_origem, caminho_arquivo_destino)
                        print(f"Copiado: {arquivo}")
                        arquivos_copiados += 1
                    except IOError as e:
                        print(f"Erro ao copiar o arquivo {arquivo}: {e}")

    print("\n---")

    print(f"Processo concluído. {arquivos_copiados} arquivo(s) XML copiado(s) para a pasta '{nome_pasta_destino}'.")

    os.system('pause')
copiar_xmls()
# Fim do script
