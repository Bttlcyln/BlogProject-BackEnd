using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        IDataResult<List<Notification>> GetAll();
        IDataResult<int>GetNotificationCount();
        IResult Add(AddNotificationRequest request);
        IResult Update(UpdateNotificationRequest request);
        IResult Delete(int notificationId);
        IDataResult<List<NotificationDetailDto>>GetAllByUserId();

    }
}
