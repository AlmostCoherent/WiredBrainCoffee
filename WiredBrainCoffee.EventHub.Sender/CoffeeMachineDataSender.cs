using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.EventHub.Sender.Model;

namespace WiredBrainCoffee.EventHub.Sender
{
    public interface ICoffeeMachineDataSender
    {
        Task SendDataAsync(CoffeeMachineData coffeeMachineData);
		Task SendDataAsync(IEnumerable<CoffeeMachineData> coffeeMachineData);
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
			EventData eventData = CreateEventData(coffeeMachineData);
			await _eventHubClient.SendAsync(eventData, "counters");
		}
		public async Task SendDataAsync(IEnumerable<CoffeeMachineData> coffeeMachineData)
		{
			var eventsData = coffeeMachineData.Select(e => CreateEventData(e));

            EventDataBatch eventDataBatch = _eventHubClient.CreateBatch();

            foreach (EventData eventData in eventsData)
            {
                if (!eventDataBatch.TryAdd(eventData))
                {
                    await _eventHubClient.SendAsync(eventDataBatch.ToEnumerable());
                    eventDataBatch = _eventHubClient.CreateBatch();
                    eventDataBatch.TryAdd(eventData);
                }
            }

            if (eventDataBatch.Count > 0)
            {
                await _eventHubClient.SendAsync(eventDataBatch);
            }
		}
		private static EventData CreateEventData(CoffeeMachineData coffeeMachineData)
		{
			var dataAsJson = JsonConvert.SerializeObject(coffeeMachineData);
			EventData eventData = new EventData(Encoding.UTF8.GetBytes(dataAsJson));
			return eventData;
		}
	}
}
