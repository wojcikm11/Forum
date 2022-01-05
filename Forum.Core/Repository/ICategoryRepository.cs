using Forum.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> BrowseAllAsync();
        Task<Category> GetAsync(int id);
        Task DelAsync(Category c);
        Task UpdateAsync(Category c);
        Task AddAsync(Category c);
    }
}
