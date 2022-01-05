using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.Models
{
    public class CreatePostVM
    {
        public String AuthorId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}
