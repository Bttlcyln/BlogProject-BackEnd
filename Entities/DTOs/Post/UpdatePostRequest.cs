using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Post
{
    public class UpdatePostRequest
    {
        public int UserId {  get; set; }
        public string Content {  get; set; }
        public int Id { get; set; }
    }
}
