using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EntityFrameWorkDbContext;
using Entities.Concrete;
using Entities.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : EfEntityRepositoryBase<Notification, AppDbContext>, INotificationDal
    {
        public List<NotificationDetailDto> GetAllByUserId(int userId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = (from notification in context.Notifications
                              join user in context.Users on notification.UserId equals user.Id into userLeftJoin
                              from user in userLeftJoin.DefaultIfEmpty()
                              where notification.UserId == userId
                              select new NotificationDetailDto
                              {
                                  Id = notification.Id,
                                  UserId = notification.UserId,
                                  IsActive = notification.IsActive,
                                  CreatedAt = notification.CreatedAt,
                                  IsRead = notification.IsRead,
                                  Title = notification.Title,                           
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  NotificationCount = (context.Notifications.Count(c=>c.UserId==userId))
                              });
                return result.ToList();
            }
        }
    }
}
