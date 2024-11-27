using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post : BaseEntity, IEntity
    {

        public int BloggerId { get; set; }
        public string Content { get; set; }        
    }
}
