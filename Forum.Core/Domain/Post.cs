using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime DatePosted { get; set; }
        public List<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}
