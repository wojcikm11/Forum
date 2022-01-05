using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
