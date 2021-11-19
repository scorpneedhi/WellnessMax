// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;

namespace EventHubReceiver
{
    class MainClass : IEventProcessor
    {
        private const string EventHubConnectionString = "";
        private const string EventHubName = "devicehub";
        private const string StorageContainerName = "mycontainer";
        private const string StorageAccountName = "mywonderfulstorage";
        private const string StorageAccountKey = "";

        private static readonly string StorageConnetionString = "";

        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Registering EventProcessing.....");

            var eventProcessorHost = new EventProcessorHost(
                EventHubName,
                PartitionReceiver.DefaultConsumerGroupName,
                EventHubConnectionString,
                StorageConnetionString,
                StorageContainerName
                );

            // Registers the Event Processor Host and start receiveing messages
            await eventProcessorHost.RegisterEventProcessorAsync<MainClass>();

            Console.WriteLine("Receiveing. Press Enter to stop worker.");
            Console.ReadLine();

            //Dispose of Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Processor Shutting Down. Partition: '{context.PartitionId}', reason: '{reason}'");
            return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"SimpleEventProcessor initialzed. Partition: '{context.PartitionId}'");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine($"Error on Partition: '{context.PartitionId}', error: '{error}'");
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach(var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                Console.WriteLine($"Message received. Partition '{context.PartitionId}', Data: '{data}'");
            }

            return context.CheckpointAsync();
        }
    }
}
