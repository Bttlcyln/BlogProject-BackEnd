using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Comment
{
    public class AddCommentRequest
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
    }
}
