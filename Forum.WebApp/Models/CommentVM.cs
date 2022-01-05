using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.Models
{
    public class CommentVM
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
