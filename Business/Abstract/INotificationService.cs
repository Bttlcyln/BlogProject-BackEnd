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
        IResult Add(AddNotificationRequest request);
        IResult Update(Notification notification);
        IResult Delete(int notificationId);
    }
}
