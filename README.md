# AZ-204 Project

## Overview
This project is designed to help you prepare for the Microsoft Azure AZ-204 certification exam. The AZ-204 exam tests your skills in developing solutions for Microsoft Azure.

## Prerequisites
- Basic knowledge of Microsoft Azure services.
- Familiarity with programming languages such as C# or Python.
- Visual Studio or any other IDE of your choice.
- Azure Subscription
- Python installed

# FileApp
## Overwiew
Build a console app to access, crate and list containers and upload files, using .net and python

## Project Structure
- `/dotnet`: Contains the source code for the dotnet project.
- `Program.cs`: Contains the main logic for connecting to Azure Storage, creating containers, and enumerating blobs.

- `/Py`: Contains the source code for the python project
- `/storage-service.py`: This Python script demonstrates how to interact with Azure Blob Storage using the Azure SDK for Python.

## Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/Raphaellaucene/AZ-204-FileApp.git
    ```
2. Navigate to the project directory:
    ```sh
    cd AZ-204-FileApp
    ```
3. Install the required dependencies:
    ```sh
    dotnet add package Azure.Storage.Blobs
    ```
## Usage
1. Open the project in your preferred IDE.
2. Create a storage account with public access
3. Change the env variables to storage account name, secret and connection string

# Cosmos App Project

## Overview
Test your skills developing a solution using a console app to crate a Azure Cosmos DB database on Azure, configure a console app, connect to Cosmos DB, create and list containers

## Installation
1. Azure Cosmos DB:
    ```sh
    pip install azure-cosmos
    ```
2. Variaveis de ambiente:
    ```sh
    pip install python-dotenv
    ```
3. Install the required dependencies:
    ```sh
    dotnet add package Azure.Storage.Blobs

# Azure Container

## Overview
Use ACR service (Azure Conatainer Registry) to developing containers and pipelines or using ACR Task to create container images to Azure.
Use ACI (Azure Container instance) to execute this images created previosly using CLI

### ACR
- Explain the benefits using ACR
- Describe how to using ACR's Task to create automatic builds and deploy
- Explain Dockerfile elements
- Create and run a ACR image using Azure CLI

### ACI
- Container Groups
- Explain restart policy
- YAML volume

## Tier
- Basic
- Standart
- Premium

# Container App
## Overview
Azure Container Apps is a fully managed serverless platform that allows you to run containerized applications without worrying about infrastructure management.

- **Serverless Management**: Azure Container Apps handles server configuration, container orchestration, and deployment details, allowing you to focus on your application.

- **Automatic Scaling**: Applications can dynamically scale based on HTTP traffic, event-driven processing, CPU or memory load, and other KEDA-supported triggers.

- **Microservices and Jobs**: You can build microservices and run jobs on-demand, on a schedule, or based on events.

- **Built-in Ingress**: Enable HTTPS or TCP ingress without managing additional infrastructure.

- **Integration with Dapr**: Build microservices with Dapr and access its rich set of APIs.

- **Blue/Green Deployments**: Split traffic across multiple versions of an application for Blue/Green deployments and A/B testing.

- **Security and Monitoring**: Securely manage secrets, monitor logs using Azure Log Analytics, and use internal ingress for secure endpoints.

# Hands-on
## Overwiew
Deploy workloads using images and containers. In this lab, we deploy a simple app for check if the network is available and, if so, retrieves and displays the current IP addresses of the host machine.

![alt text](image.png)

## Configurations
1. Compress to Archive PS:(local):
    ```sh
    Compress-Archive -Path .\* -DestinationPath .\LabHandsOn.zip
    ```
2. List Subscriptions (Azure CLI)
    ```sh
    az account list --output table
    ```
3. Create project folder:
    ```sh
    mkdir ~/ipcheck

4. Unzip folder:
    ```sh
    unzip ~/LabHandsOn.zip -d ~/ipcheck

5. Change permissions:
    ```sh
    chmod -R +xr ~/ipcheck

6. Create registry:
    ```sh
    registryName=conregistry$RANDOM

7. Listen registry:
    ```sh
    echo $resgistryName

8. Check ACR:
    ```sh
    az acr check-name --name $registryName

9. Create ACR:
    ```sh
    az acr Create --resource-group $rg --name $registryName --sku Basic

10. list acrs:
    ```sh
    az acr list --resource-group $rg

11. list acr by date:
    ```sh
    acrName=$(az acr list --resource-group $rg --query "max_by([], &creationDate).name" --output tsv)

12. Listen acr:
    ```sh
    echo $acrName

13. Build image:
    ```sh
    az acr build --registry $acrName --image ipcheck:latest .

14. Enable admin user:
    ```sh
    az acr update -n $acrName --admin-enable true


## Contact
For any questions or feedback, please open an issue on the [GitHub repository](https://github.com/Raphaellaucene/AZ-204-FileApp).
