using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WiredBrainCoffee.EventHub.EventSenderFunction.Services;
using Handlers;

namespace WiredBrainCoffee.EventHub.EventSenderFunction
{
    public class CoffeeMachineDataProvider
    {
        ICoffeeMachineDataService _coffeeMachineDataService;
        public CoffeeMachineDataProvider(ICoffeeMachineDataService coffeeMachineDataService)
        {
            _coffeeMachineDataService = coffeeMachineDataService;
        }

        [FunctionName("CoffeeMachineDataProvider")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("CoffeeMachineDataProviderPost")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function,"post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            CoffeeMachinePostHandler coffeeMachinePostHandler = new CoffeeMachinePostHandler(_coffeeMachineDataService);
            await coffeeMachinePostHandler.Handle(req);


            return new OkObjectResult("");
        }
    }
}
