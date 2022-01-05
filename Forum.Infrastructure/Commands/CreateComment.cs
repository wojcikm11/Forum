using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.Commands
{
    public class CreateComment
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Comment { get; set; }
    }
}
