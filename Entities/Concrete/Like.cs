using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Like : BaseEntity, IEntity
    {
        public  int  PostId { get; set; }
        public int UserId { get; set; }

    }
}
