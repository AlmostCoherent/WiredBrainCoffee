using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.EvenHub.EventSenderFunction.Services
{
    public interface IDataSenderService
    {
        Task SendDataAsync();
    }
    public class DataSenderService : IDataSenderService
    {
        private const string connectionString = "Endpoint=sb://wiredbraincoffeeeh-namespace.servicebus.windows.net/;SharedAccessKeyName=SendAndListed;SharedAccessKey=PDcO+pXauyge97stMJY/yONJWgBoiisJfedJ+TiiHdU=";
        private const string eventHubName = "wiredbraincoffeeeh";
        public async Task SendDataAsync()
        {
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
               // Create a batch of events
               EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                // Add events to the batch. An event is a represented by a collection of bytes and metadata. 
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Third event")));

                // Use the producer client to send the batch of events to the event hub
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("A batch of 3 events has been published.");
            }
        }
    }
}
