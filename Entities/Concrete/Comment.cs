using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : BaseEntity, IEntity
    {
        public int BloggerId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
        
    }
}
