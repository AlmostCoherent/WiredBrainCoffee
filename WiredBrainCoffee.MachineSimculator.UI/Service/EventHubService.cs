using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.EventHub.Sender.Model;

namespace WiredBrainCoffee.MachineSimculator.UI.Service
{ 
    public interface IEventHubService
    {
        Task SendEventData(IEnumerable<CoffeeMachineData> coffeeMachineData);
    }
    public class EventHubService : IEventHubService
    {
        private HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44347/event/send");
        static HttpClient client = new HttpClient();

        public async Task SendEventData(IEnumerable<CoffeeMachineData> coffeeMachineData)
        {
            var body = JsonConvert.SerializeObject(coffeeMachineData);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44347/event/send", content);
        }

    }
}
