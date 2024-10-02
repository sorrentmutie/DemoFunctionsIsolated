using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoDunctionsIsolated
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IClock clock;

        public Function1(ILogger<Function1> logger, IClock clock)
        {
            _logger = logger;
            this.clock = clock;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"{clock.GetNow()}: Welcome to Azure Functions!!!!");
        }
    }
}
