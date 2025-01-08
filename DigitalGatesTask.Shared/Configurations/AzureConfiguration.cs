using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Shared.Configurations
{
    public static class AzureConfiguration
    {
        public static ServiceBus UserManagment => new ServiceBus { Title = "User Managment", Name = "users-management-bus", TopicName = "registration", ConnectionString = "Endpoint=sb://users-management-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kvJvCjzxCCYA3GaNPp8cSaygcaYJ3YM4e+ASbPtdsoA=" };
        public static ServiceBus Notifications => new ServiceBus { Title = "Notifications", Name = "testApp-notifications-bus", TopicName = "notifications", ConnectionString = "Endpoint=sb://testapp-notifications-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=s4gCY/NFIMxzZ0o6GlL/fQMHRAB80lZHU+ASbIFUBWI=" };
    }

    public class ServiceBus
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string TopicName { get; set; }
        public string ConnectionString { get; set; }
    }
}
