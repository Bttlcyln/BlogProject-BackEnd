using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PostDetailDto : IDto
    {
        //public int UserId { get; set; }
        //public string Content { get; set; }
        //public string Title { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CommentCount { get; set; }
    }
}
