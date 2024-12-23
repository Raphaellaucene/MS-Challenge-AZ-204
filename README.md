# AZ-204 File App Project

## Overview
This project is designed to help you prepare for the Microsoft Azure AZ-204 certification exam. The AZ-204 exam tests your skills in developing solutions for Microsoft Azure, using a console app to access, crate and list containers and upload files

## Project Structure
- `/dotnet`: Contains the source code for the dotnet project.
- `Program.cs`: Contains the main logic for connecting to Azure Storage, creating containers, and enumerating blobs.

- `/Py`: Contains the source code for the python project
- `/storage-service.py`: This Python script demonstrates how to interact with Azure Blob Storage using the Azure SDK for Python.

## Prerequisites
- Basic knowledge of Microsoft Azure services.
- Familiarity with programming languages such as C# or Python.
- Visual Studio or any other IDE of your choice.
- Azure Subscription
- Python installed

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

# Tier
- Basic
- Standart
- Premium

## Contact
For any questions or feedback, please open an issue on the [GitHub repository](https://github.com/Raphaellaucene/AZ-204-FileApp).
