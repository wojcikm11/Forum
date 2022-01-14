using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.Models
{
    public class PostListVM
    {
        public List<PostVM> Posts { get; set; }
        public int RecentPosts { get; set; }
    }
}
