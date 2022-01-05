using Forum.Core.Domain;
using Forum.Core.Repository;
using Forum.Infrastructure.Commands;
using Forum.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddAsync(CreateUser u)
        {
            await _userRepository.AddAsync(Map(u));
        }

        public async Task<IEnumerable<UserDTO>> BrowseAll()
        {
            var users = await _userRepository.BrowseAllAsync();
            return users.Select(u => Map(u));
        }

        public async Task DelAsync(string id)
        {
            var user = _userRepository.GetAsync(id).Result;
            await _userRepository.DelAsync(user);
        }

        public async Task<UserDTO> GetAsync(string id)
        {
            return await Task.FromResult(Map(_userRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(string id, UpdateUser u)
        {
            await _userRepository.UpdateAsync(Map(u, id));
        }

        private User Map(CreateUser c)
        {
            return new User()
            {
                UserName = c.UserName
            };
        }

        private UserDTO Map(User u)
        {
            if (u.UserInfo != null)
            {
                return new UserDTO()
                {
                    UserId = u.Id,
                    UserInfoId = u.UserInfo.Id.ToString(),
                    UserName = u.UserName,
                    FirstName = u.UserInfo.FirstName,
                    LastName = u.UserInfo.LastName,
                    Town = u.UserInfo.Town
                };
            }
            return new UserDTO()
            {
                UserId = u.Id,
                UserInfoId = null,
                UserName = u.UserName,
                FirstName = null,
                LastName = null,
                Town = null
            };
        }

        private User Map(UpdateUser u, string id)
        {
            var user = _userRepository.GetAsync(id).Result;
            return new User()
            {
                Id = id,
                UserName = u.Username,
                UserInfo = user.UserInfo,
                UserPosts = user.UserPosts,
                UserComments = user.UserComments
            };
        }
    }
}
