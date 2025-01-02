using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsKeyVault
{
    public class FileParses
    {
        private readonly ILogger<FileParses> _logger;

        public FileParses(ILogger<FileParses> logger)
        {
            _logger = logger;
        }

        [Function("FileParses")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            // Get the connection string from the environment
            string ConnectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

            // Get the blob client
            BlobClient blob = new BlobClient(ConnectionString, "drop", "records.json");

            // Download the blob's contents and save it to a file
            BlobDownloadResult downloadResult = blob.DownloadContent();

            // Retrieve the blob's content and convert it to a string
            await response.WriteStringAsync(downloadResult.Content.ToString());

            return response;
        }
    }
}
