using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.Commands
{
    public class CreatePost
    {
        public string AuthorId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}
