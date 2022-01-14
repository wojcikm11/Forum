using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.DTO
{
    public class PostListDTO
    {
        public List<PostDTO> Posts { get; set; }
        public int RecentPosts { get; set; }
    }
}
