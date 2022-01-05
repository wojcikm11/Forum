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
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUserRepository _userRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository, IUserRepository userRepository)
        {
            _userInfoRepository = userInfoRepository;
            _userRepository = userRepository;
        }

        public async Task AddAsync(CreateUserInfo u)
        {
            await _userInfoRepository.AddAsync(Map(u));
        }

        public async Task<IEnumerable<UserInfoDTO>> BrowseAll()
        {
            var usersInfo = await _userInfoRepository.BrowseAllAsync();
            return usersInfo.Select(u => Map(u));
        }

        public async Task DelAsync(int id)
        {
            var userInfo = _userInfoRepository.GetAsync(id).Result;
            await _userInfoRepository.DelAsync(userInfo);
        }

        public async Task<UserInfoDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_userInfoRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(int id, UpdateUserInfo u)
        {
            await _userInfoRepository.UpdateAsync(Map(u, id));
        }

        private UserInfo Map(CreateUserInfo u)
        {
            return new UserInfo()
            {
                User = _userRepository.GetAsync(u.UserId).Result,
                UserId = _userRepository.GetAsync(u.UserId).Result.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Town = u.Town
            };
        }

        private UserInfoDTO Map(UserInfo u)
        {
            return new UserInfoDTO()
            {
                Id = u.Id.ToString(),
                UserId = u.User.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Town = u.Town
            };
        }

        private UserInfo Map(UpdateUserInfo u, int id)
        {
            User user = _userRepository.GetAsyncByInfoId(id).Result;
            return new UserInfo()
            {
                Id = id,
                User = user,
                UserId = user.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Town = u.Town
            };
        }
    }
}
