using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure.DTO
{
    public class UserInfoDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Town { get; set; }
    }
}
