using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.EventHub.Sender.Model;

namespace WiredBrainCoffee.EventHub.Sender
{
    public interface ICoffeeMachineDataSender
    {
        Task SendDataAsync(CoffeeMachineData coffeeMachineData);
    }
    public class CoffeeMachineDataSender : ICoffeeMachineDataSender
    {
        private EventHubClient _eventHubClient;

        public CoffeeMachineDataSender(string eventHubConnectionString)
        {
            _eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionString);
        }

        public async Task SendDataAsync(CoffeeMachineData coffeeMachineData)
        {
            var dataAsJson = JsonConvert.SerializeObject(coffeeMachineData);
            EventData eventData = new EventData(Encoding.UTF8.GetBytes(dataAsJson));
            await _eventHubClient.SendAsync(eventData);
        }
    }
}
