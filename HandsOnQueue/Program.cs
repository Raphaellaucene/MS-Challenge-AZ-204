using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

space MessagePublisher {
    Public class Program {
        private const string ServiceBusConnectionString = "Endpoint=sb://<namespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=<key
        private const string queueName = "messagequeue";

        private const int numberOfMessages = 3;

        static ServiceBusClient client = default;

        static ServiceBusSender sender = default;

        public static async Task Main(string[] args) {

            client = new ServiceBusClient(ServiceBusConnectionString);
            sender = client.CreateSender(queueName);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            for (int i = 0; i < numberOfMessages; i++) {
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}"))) {

                    throw new Exception($"The message {i} is too large to fit in the batch.");
                }
            }
            try {
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {numberOfMessages} messages has been published to the queue.");
            }
            finally {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}