using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Threading.Tasks;

namespace WiredBrainCoffee.EventHub.Receivers.Processor
{
    class Program
    {
        private const string eventHubPath = "wiredbraincoffeeeh";
        private const string consumerGroupName = "wired_brain_coffee_console_processor";
        private const string eventHubConnectionString = "Endpoint=sb://wiredbraincoffeeeh-namespace.servicebus.windows.net/;SharedAccessKeyName=SendAndListed;SharedAccessKey=PDcO+pXauyge97stMJY/yONJWgBoiisJfedJ+TiiHdU=";
        private const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=wiredbraincoffeeblobstr;AccountKey=T87S+z3VQHF1TmKm2QRdcg56gcupThDGLfFGKrIHnJds/kRbA3GnnyRGocjeW2xfToJUf/eORouFfjNmekzYYw==;EndpointSuffix=core.windows.net";
        private const string leaseContainerName = "processcheckpoint";
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine($"Register the { nameof(WiredBrainCoffeeEventProcessor) }");

            EventProcessorHost eventProcessorHost = new EventProcessorHost(
                eventHubPath,
                consumerGroupName,
                eventHubConnectionString,
                storageConnectionString,
                leaseContainerName);

            await eventProcessorHost.RegisterEventProcessorAsync<WiredBrainCoffeeEventProcessor>();

            Console.WriteLine($"Waiting for incoming events...");
            Console.WriteLine($"Press any key to shut down. ");
            Console.ReadLine();

            await eventProcessorHost.UnregisterEventProcessorAsync();

        }
    }
}
