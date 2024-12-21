using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Notification : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }
    }
}
