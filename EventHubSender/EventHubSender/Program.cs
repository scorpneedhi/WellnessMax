// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;

namespace EventHubSender
{ 
    class MainClass
    {
        private static EventHubClient eventHubClient;
        private const string EventConnectionString = "";
        private const string EventHubName = "devicehub";
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        private static async Task MainAsync(string[] args)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventConnectionString)
            {
                EntityPath = EventHubName
            };
            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub(100);

            Console.WriteLine("Please Enter to Exit");
            Console.ReadLine();

            await eventHubClient.CloseAsync();
        }
        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            for(int i = 0; i < numMessagesToSend; i++)
            {
                var message = new PayloadGenerator().Payload();
                Console.WriteLine($"Sending message:{message}");

                await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));

                await Task.Delay(100);
            }
            Console.WriteLine($"{numMessagesToSend} messages sent");
        }
    }
}

