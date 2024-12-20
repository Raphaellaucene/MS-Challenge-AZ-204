using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public class Program
{
    //update the storageAccountName value that you recorded previously in this lab.
    private const string storageAccountName = "stlabaz204eus2";

    //Update the blobServiceEndpoint value that you recorded previously in this lab.
    private const string blobServiceEndpoint = $"https://{storageAccountName}.blob.core.windows.net/";


    //update the storageAccountKey value that you recorded previously in this lab.
    private const string storageAccountKey = "1OPwC+qwDvfghjxVE9WQo7WYbLuzIWQDZVH4GGOgPs0h/MaM1dsv7NouLCwrSGlFzqbJs8dXkNt++ASt28AiDw==";

    //The following code creates a new async Main method.
    public static async Task Main(string[] args)
    {
        //The following code creates a new instance of the StorageSharedKeyCredential class.
        StorageSharedKeyCredential accountCredentials = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

        //The following line of code creates a new instanve of the BlobServiceClient class.
        BlobServiceClient serviceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), accountCredentials);

        //The following code invoke the GetAccountInfoAsync method of the BlobServiceClient class to get the account information.
        AccountInfo info = await serviceClient.GetAccountInfoAsync();

        //Render a welcome message
        await Console.Out.WriteLineAsync($"Connected to the Azure Storage Account");

        //Render the storage account name
        await Console.Out.WriteLineAsync($"Account name:\t{storageAccountName}");

        //Render the storage account kind
        await Console.Out.WriteLineAsync($"Kind:\t{info?.AccountKind}");

        //Render the storage account sku
        await Console.Out.WriteLineAsync($"SKU:\t{info?.SkuName}");

        await GetBlobContainerAsync(serviceClient, "images");

        await EnumerateContainersAsync(serviceClient);
    }
    private static async Task EnumerateContainersAsync(BlobServiceClient client)
    {
        //Create an async enumerator to enumerate the containers in the storage account.
        await foreach (BlobContainerItem container in client.GetBlobContainersAsync())
        {
            await Console.Out.WriteLineAsync($"Container:\t{container.Name}");
            await EnumerateBlobsAsync(client, container.Name);
        }
    }
    private static async Task EnumerateBlobsAsync(BlobServiceClient client, string containerName)
    {
       //Get a new instance of the BlobContainerClient class.
        BlobContainerClient container = client.GetBlobContainerClient(containerName);

        //Render the container name
        await Console.Out.WriteLineAsync($"Searching:\t{container.Name}");

        //Create an async enumerator to enumerate the blobs in the container.
        await foreach (BlobItem blob in container.GetBlobsAsync())
        {
            await Console.Out.WriteLineAsync($"Blob:\t{blob.Name}");
        }
    }
    private static async Task<BlobContainerClient> GetBlobContainerAsync(BlobServiceClient client, string containerName)
    {
        //Get a new instance of the BlobContainerClient class.
        BlobContainerClient container = client.GetBlobContainerClient(containerName);

        //invoke the CreateIfNotExistsAsync method of the BlobContainerClient class to create the container if it does not exist.
        await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

        //render a message to the console
        await Console.Out.WriteLineAsync($"New Container:\t{container.Name}");

        return container;
    }
    private static async Task<BlobClient> GetBlobAsync(BlobContainerClient client, string blobName)
    {
        //Get a new instance of the BlobClient class.
        BlobClient blob = client.GetBlobClient(blobName);
        bool exists = await blob.ExistsAsync();
        if (!exists)
        {
            await Console.Out.WriteLineAsync($"Blob does not exist:\t{blob.Name}");
        }
        else
        {
            await Console.Out.WriteLineAsync($"Blob Found, URI:\t{blob.Uri}");
        }
        return blob;
    }
}
