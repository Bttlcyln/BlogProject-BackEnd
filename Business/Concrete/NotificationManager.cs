using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        public IResult Add(Notification notification)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int notificationId)
        {
            throw new NotImplementedException();
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
