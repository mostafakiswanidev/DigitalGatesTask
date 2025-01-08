using DigitalGatesTask.Shared.Dtos;
using DigitalGatesTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Shared.Notifications
{
    public class EmailNotification
    {
        public UserDetailsDto UserDetails { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
