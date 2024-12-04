using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Like
{
    public class AddLikeRequest
    {
        public  int PostId { get; set; }
        public int UserId { get; set; }
    }
}
