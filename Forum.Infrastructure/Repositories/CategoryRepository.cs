using Forum.Core.Domain;
using Forum.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task AddAsync(Category c)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Category c)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category c)
        {
            throw new NotImplementedException();
        }
    }
}
