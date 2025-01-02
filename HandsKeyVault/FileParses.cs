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
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");
            response.WriteString(connectionString);

            return Task.FromResult(response);
        }
    }
}
