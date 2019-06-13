using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.EventHub.Receivers.Direct
{
    public class WiredBrainCoffeePartitionReceiveHandler : IPartitionReceiveHandler
    {
        public string _partitionId { get; set; }
        public WiredBrainCoffeePartitionReceiveHandler(string partitionId)
        {
            _partitionId = partitionId;
        }
        public int MaxBatchSize { get; set; } = 10;

        public Task ProcessErrorAsync(Exception error)
        {
            Console.WriteLine($"Exception: { error.Message }");
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(IEnumerable<EventData> eventDatas)
        {
            if (eventDatas != null)
            {
                foreach (EventData data in eventDatas)
                {
                    var dataAsJson = Encoding.UTF8.GetString(data.Body.Array);
                    Console.WriteLine($"{dataAsJson} | PartitionId: { _partitionId }");
                }
            }

            return Task.CompletedTask;
        }
    }
}
