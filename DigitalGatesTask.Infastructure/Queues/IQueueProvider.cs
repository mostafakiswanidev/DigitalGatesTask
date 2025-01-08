using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Infastructure.Queues
{
    public interface IQueueProvider
    {
        public string ServiceBusName { get; set; }
        public string ConnectionString { get; set; }
        Task SendMessageToTopicAsync(string topic, dynamic dto);
    }
}
