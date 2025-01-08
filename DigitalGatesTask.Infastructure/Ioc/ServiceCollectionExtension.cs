using DigitalGatesTask.Infastructure.MailSender;
using DigitalGatesTask.Infastructure.Queues;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Infastructure.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterInfastructure(this IServiceCollection services)
        {
            services.AddScoped<IQueueProvider, AzureServiceBus>();

            return services;
        }
    }
}
