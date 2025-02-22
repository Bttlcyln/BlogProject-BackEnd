using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Notification
{
    public class UpdateNotificationRequest
    {
       
        public bool IsRead { get; set; }
        public int Id { get; set; }
    }
}
