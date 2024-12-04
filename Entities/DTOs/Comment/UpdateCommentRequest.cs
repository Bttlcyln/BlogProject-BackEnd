using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Comment
{
    public class UpdateCommentRequest
    {
        public int USerId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
