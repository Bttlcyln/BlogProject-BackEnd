using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public IResult Add(AddNotificationRequest request)
        {
            Notification notificationEntity = new Notification()
            {
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = request.UserId,
            };
            _notificationDal.Add(notificationEntity);
            return new SuccessResult();
        }

        public IResult Delete(int notificationId)
        {
            Notification notification = _notificationDal.Get(n => n.Id ==notificationId);
            _notificationDal.Delete(notification);
            return new SuccessResult();
        }

        public IDataResult<List<Notification>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
