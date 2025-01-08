using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using DigitalGatesTask.Infastructure.MailSender;
using DigitalGatesTask.Shared.Notifications;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DigitalGatesTask.Notifications
{
    public class EmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private EmailProvider emailProvider;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;

            var serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            emailProvider = new EmailProvider();
        }

        [Function(nameof(EmailSender))]
        public async Task Run(
            [ServiceBusTrigger("notifications", "mail-sender", Connection = "ConnectionString")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            try
            {
                var notification = JsonConvert.DeserializeObject<EmailNotification>(message.Body.ToString());

                var result = await emailProvider.SendEmailAsync(notification.UserDetails.Email, "Welcome", "welcome to our test app");
                if (result.IsFailure)
                {
                    //TODO:: do something
                }

                // Complete the message
                await messageActions.CompleteMessageAsync(message);

            }
            catch (Exception ex)
            {
                //TODO:: handle exceptions here
                throw;
            }
        }
    }
}
