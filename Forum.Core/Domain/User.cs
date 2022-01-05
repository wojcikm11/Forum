using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Domain
{
    public class User : IdentityUser
    {
        public UserInfo UserInfo { get; set; }
        public List<Post> UserPosts { get; set; }
        public List<Comment> UserComments { get; set; }

        public User()
        {
            UserPosts = new List<Post>();
            UserComments = new List<Comment>();
        }
    }
}
