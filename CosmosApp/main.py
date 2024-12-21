from azure.cosmos import CosmosClient, PartitionKey, exceptions
from dotenv import load_dotenv
import os
load_dotenv()

URL = os.getenv('COSMOS_URL')
KEY = os.getenv('COSMOS_KEY')
DATABASE_NAME = os.getenv('COSMOS_DATABASE')
CONTAINER_NAME = os.getenv('COSMOS_CONTAINER')

client = CosmosClient(URL, KEY)

#Create a database
def create_database():
    try:
        database = client.create_database(DATABASE_NAME)
        print(f"Database created: '{database.id}'")
    except exceptions.CosmosResourceExistsError:
        
        database = client.get_database_client(DATABASE_NAME)
        print(f"Database '{DATABASE_NAME}' already exists")

        return database
    
#Create a container
def create_container(database):
    try:
        container = database.create_container(id=CONTAINER_NAME, partition_key=PartitionKey(path="/id"))
        print(f"Container created: '{container.id}'")
    except exceptions.CosmosResourceExistsError:
        container = database.get_container_client(CONTAINER_NAME)
        print(f"Container '{CONTAINER_NAME}' already exists")

        return container
    
#Create a item
def create_item(container, item):
    container.create_item(body=item)
    print(f"Item created: '{item}'")

def update_item(container):
    item = container.read_item(item="1", partition_key="1")
    item['price'] = 200
    container.upsert_item(body=item)
    print(f"Item updated: '{item}'")

def delete_item(container):
    container.delete_item(item="1", partition_key="1")
    print(f"Item deleted")

def read_allitems(container):
    item = container.read_all_items()
    for item in items:
        print(item)

def read_item(container):
    item = container.read_item(item="1", partition_key="1")
    print(f"Item read: '{item}'")

if __name__ == "__main__":
    database = create_database()
    container = create_container(database)

    item = {
        "id": "3",
        "ProductID": "1",
        "ProductName": "Mouse Pad",
        "description": "Made of rubber, 10x10 inches",
        "price": 15.00
    }

create_item(container, item)
update_item(container)
delete_item(container)
read_allitems(container)
read_item(container)