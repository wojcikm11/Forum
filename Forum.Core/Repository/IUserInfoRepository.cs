using Forum.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repository
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<UserInfo>> BrowseAllAsync();
        Task<UserInfo> GetAsync(int id);
        Task DelAsync(UserInfo u);
        Task UpdateAsync(UserInfo u);
        Task AddAsync(UserInfo u);
    }
}
