using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Infastructure.Queues
{
    public class AzureServiceBus : IQueueProvider
    {
        public string ServiceBusName { get; set; }
        public string ConnectionString { get; set; }

        public async Task SendMessageToTopicAsync(string topic, dynamic dto)
        {
            await using var client = new ServiceBusClient(ConnectionString);

            // Create a sender for the topic
            ServiceBusSender sender = client.CreateSender(topic);

            try
            {
                // Serialize the object to a JSON string
                string jsonMessage = JsonConvert.SerializeObject(dto);

                // Create the Service Bus message
                ServiceBusMessage message = new ServiceBusMessage(jsonMessage)
                {
                    ContentType = "application/json", // Set the content type to JSON
                    MessageId = Guid.NewGuid().ToString(), // Optional: Set a unique message ID
                };

                // Send the message
                await sender.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                //log the error
            }
            finally
            {
                await sender.DisposeAsync();
            }
        }
    }
}
