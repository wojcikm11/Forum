
using Forum.Infrastructure.Commands;
using Forum.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Service
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> BrowseAll();
        Task<PostDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdatePost p);
        Task AddAsync(CreatePost p);
    }
}
