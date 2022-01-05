using Forum.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> BrowseAllAsync();
        Task<IEnumerable<Comment>> BrowseAllAsync(int postId);
        Task<IEnumerable<Comment>> BrowseAllAsyncByUser(string userId);
        Task<Comment> GetAsync(int id);
        Task DelAsync(Comment c);
        Task UpdateAsync(Comment c);
        Task AddAsync(Comment c);
    }
}
