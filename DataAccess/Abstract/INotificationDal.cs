﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INotificationDal :IEntityRepository<Notification>
    {
        List<NotificationDetailDto> GetAllByUserId(int userId);
    }
}
