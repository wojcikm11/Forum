using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public List<Post> Posts { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
