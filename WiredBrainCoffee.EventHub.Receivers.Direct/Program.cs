using Microsoft.Azure.EventHubs;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.EventHub.Receivers.Direct
{
    class Program
    {
        const string connectionString = "Endpoint=sb://wiredbraincoffeeeh-namespace.servicebus.windows.net/;SharedAccessKeyName=SendAndListenPolicy;SharedAccessKey=7zNbQQbMEENr5ag4rCs7fjY7URRa5ZOlVO9d9s0Z3xw=;EntityPath=wiredbraincoffeeeh";
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("Connecting to event hub...");
            var eventHubClient =
                    EventHubClient.CreateFromConnectionString(connectionString);

            var runtimeInformation = await eventHubClient.GetRuntimeInformationAsync();

            var partitionReceivers = runtimeInformation.PartitionIds.Select(partitionId => 
                                                eventHubClient.CreateReceiver("wired_brain_coffee_console_direct", partitionId, EventPosition.FromStart())).ToList();

            Console.WriteLine("Waiting for incoming events...");

            foreach(var partitionReceiver in partitionReceivers)
            {
                partitionReceiver.SetReceiveHandler(
                    new WiredBrainCoffeePartitionReceiveHandler(partitionReceiver.PartitionId));
            }

            Console.WriteLine($"Press any key to shut down");
            Console.ReadLine();
            await eventHubClient.CloseAsync();
        }
    }
}
