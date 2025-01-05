using Azure;
using Azure.Messaging.EventGrid;
using System;
using System.Threading.Tasks;

public class Program
{
    private const string topicEndpoint = "<topic-endpoint>";
    private const string topicKey = "<topic-key>";
    public static async Task Main(string[] args)
    {
        Uri endpoint = new Uri(topicEndpoint);

        AzureKeyCredential credential = new AzureKeyCredential(topicKey);

        EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);

        EventGridEvent[] events = new EventGridEvent[]
        {
            new EventGridEvent(
                subject: $"http://localhost:5000/api/fnvalidacpf",
                eventType: "HandsOnValidaCPF",
                dataVersion: "1.0",
                data: new
                {
                    cpf = "12345678909"
                }
            )
        };

        await client.SendEventsAsync(events);

        Console.WriteLine("Events published.");
    }
}