﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Post
{
    public class AddPostRequest
    {
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
