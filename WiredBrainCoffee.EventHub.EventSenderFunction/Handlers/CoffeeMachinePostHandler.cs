using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WiredBrainCoffee.EvenHub.EventSenderFunction.Model;
using WiredBrainCoffee.EventHub.EventSenderFunction.Services;

namespace Handlers
{
    internal class CoffeeMachinePostHandler
    {
        ICoffeeMachineDataService _coffeeMachineDataService;
        public CoffeeMachinePostHandler(ICoffeeMachineDataService coffeeMachineDataService)
        {
            _coffeeMachineDataService = coffeeMachineDataService;
        }

        internal async Task Handle(HttpRequest req)
        {
            var data = GetBodyContent(req);
            await _coffeeMachineDataService.SendDataAsync(data);
        }
        private List<CoffeeMachineData> GetBodyContent(HttpRequest request)
        {
            string requestContent;
            using (var reader = new StreamReader(request.Body))
            {   
                requestContent = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<CoffeeMachineData>>(requestContent); ;
        }
    }
}