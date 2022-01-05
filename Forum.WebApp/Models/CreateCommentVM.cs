using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.Models
{
    public class CreateCommentVM
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Comment { get; set; }
    }
}
