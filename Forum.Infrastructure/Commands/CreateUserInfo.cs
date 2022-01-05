using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.Commands
{
    public class CreateUserInfo
    {
        public string UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Town { get; set; }
    }
}
