from azure.storage.blob import BlobClient, ContainerClient, PublicAccess, BlobServiceClient
from dotenv import load_dotenv
import os
load_dotenv()

connection_string = os.getenv('AZURE_STORAGE_CONNECTION_STRING')

def upload_file_blob_client(container_name: str):
    BlobClient = BlobClient.from_connection_string(connection_string, container_name, "arquivo.txt")
    # Upload de arquivo para o blob
    with open("arquivo.txt", "rb") as data:
        BlobClient.upload_blob(data)
        print("Arquivo enviado com sucesso!")

        # Download de arquivo do blob
        with open("arquivo.txt", "wb") as data:
            download_file = BlobClient.download_blob()
            data.write(download_file.readall())
            print("Arquivo baixado com sucesso!")
    
def admin_containers(operation: str):
    container_client = ContainerClient.from_connection_string(
        conn_str = connection_string,
        container_name = "container-teste"
    )

    match operation:
        case "list":
        # Listar todos os blobs do container
            print("Blobs no container:")
            for blob in container_client.list_blobs():
                print(blob.name)
        
        case "create":
        # Criar container se ele não existir
            container_client.create_container()
            print("Container criado com sucesso!")

        case "delete":
        # Deletar container
            container_client.delete_container()
            print("Container deletado com sucesso!")

def service_blob(container_name: str):

    blob_service_client = BlobServiceClient.from_connection_string(conn_str = connection_string)

    container_client = blob_service_client.get_container_client(container_name)

    properties = container_client.get_container_properties()
    print(f"Nível de acesso do container: {properties.public_access}")

    #Alterar nível de acesso para anônimo
    container_client.set_container_access_policy(PublicAccess = PublicAccess.Blob, signed_identifiers = {})

    print(f"O nível de acesso do container '{container_name}' foi alterado para {PublicAccess.Blob}")

admin_containers("create")
admin_containers("list")
upload_file_blob_client("container-teste")
service_blob("container-teste")