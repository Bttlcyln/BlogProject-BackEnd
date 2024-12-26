using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Notification;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationService(INotificationDal notificationDal, IHttpContextAccessor httpContextAccessor)
        {
            _notificationDal = notificationDal;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(AddNotificationRequest request)
        {
            int userId =_httpContextAccessor.GetUserId();
            Notification notificationEntity = new Notification()
            {
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = request.UserId,
                Title = request.Title,
                IsRead = true,
            };
            _notificationDal.Add(notificationEntity);
            return new Result(true,"");
        }

        public IResult Delete(int notificationId)
        {
            Notification notification = _notificationDal.Get(n => n.Id ==notificationId);
            _notificationDal.Delete(notification);
            return new SuccessResult();
        }

        public IDataResult<List<Notification>> GetAll()
        {
            return new SuccessDataResult<List<Notification>>(_notificationDal.GetAll(),Messages.NotificationListed);
        }

        public IDataResult<List<NotificationDetailDto>> GetAllByUserId()
        {
            int userId = _httpContextAccessor.GetUserId();

            return new SuccessDataResult<List<NotificationDetailDto>>(_notificationDal.GetAllByUserId(userId)); 
        }

        public IResult Update(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
