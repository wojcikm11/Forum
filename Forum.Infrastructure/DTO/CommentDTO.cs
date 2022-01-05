using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.DTO
{
    public class CommentDTO
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; } 
    }
}
