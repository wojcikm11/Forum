using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserInfoId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Town { get; set; }
    }
}
