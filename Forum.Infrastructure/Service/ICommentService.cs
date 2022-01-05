using Forum.Infrastructure.Commands;
using Forum.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Service
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> BrowseAllAsync();
        Task<IEnumerable<CommentDTO>> BrowseAllAsync(int postId);
        Task<CommentDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateComment c);
        Task AddAsync(CreateComment c);
    }
}
