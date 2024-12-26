using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Notification
{
    public class GetNotificationCountDto : IDto
    {
        public int NotificationCount { get; set; }
    }
}
