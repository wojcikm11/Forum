using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public String Content { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
