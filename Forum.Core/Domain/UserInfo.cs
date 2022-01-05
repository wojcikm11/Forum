using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Domain
{
    public class UserInfo
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Town { get; set; }
    }
}
