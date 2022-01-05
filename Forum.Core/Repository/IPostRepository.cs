using Forum.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> BrowseAllAsync();
        Task<IEnumerable<Post>> BrowseAllAsyncByUser(string userId);
        Task<Post> GetAsync(int id);
        Task DelAsync(Post p);
        Task UpdateAsync(Post p);
        Task AddAsync(Post p);
    }
}
