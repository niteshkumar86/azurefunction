using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OptiWebhook
{
    public class OptimizelyWebhook
    {
        private readonly ILogger<OptimizelyWebhook> _logger;

        public OptimizelyWebhook(ILogger<OptimizelyWebhook> logger)
        {
            _logger = logger;
        }

        [Function("OptiWebhook")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var body = new StreamReader(req.Body).ReadToEndAsync().GetAwaiter().GetResult();

            _logger.LogInformation("🔔 Optimizely Webhook received");
            _logger.LogInformation(body);

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
