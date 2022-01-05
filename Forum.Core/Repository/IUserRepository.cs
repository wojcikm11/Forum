using Forum.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> BrowseAllAsync();
        Task<User> GetAsync(string id);
        Task<User> GetAsyncByInfoId(int id);
        Task DelAsync(User u);
        Task UpdateAsync(User u);
        Task AddAsync(User u);
    }
}
