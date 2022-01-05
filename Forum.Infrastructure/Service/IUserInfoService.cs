using Forum.Infrastructure.Commands;
using Forum.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Service
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfoDTO>> BrowseAll();
        Task<UserInfoDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateUserInfo u);
        Task AddAsync(CreateUserInfo u);
    }
}
