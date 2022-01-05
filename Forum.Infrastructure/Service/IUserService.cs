using Forum.Infrastructure.Commands;
using Forum.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> BrowseAll();
        Task<UserDTO> GetAsync(string id);
        Task DelAsync(string id);
        Task UpdateAsync(string id, UpdateUser u);
        Task AddAsync(CreateUser u);
    }
}
