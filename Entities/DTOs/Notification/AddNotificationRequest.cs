﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Notification
{
    public class AddNotificationRequest
    {
        public int UserId { get; set;}
        public string Title { get; set; }
        public bool IsRead { get; set; }
    }
}
