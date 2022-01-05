using Forum.Core.Domain;
using Forum.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Post p)
        {
            try
            {
                _appDbContext.Post.Add(p);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Post>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Post.Include(p => p.Author).Include(p => p.Comments));
        }

        public async Task<IEnumerable<Post>> BrowseAllAsyncByUser(string userId)
        {
            return await Task.FromResult(_appDbContext.Post.Where(p => p.Author.Id == userId));
        }

        public async Task DelAsync(Post p)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Post.FirstOrDefault(x => x.Id == p.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Post> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Post.Include(p => p.Author).Include(p => p.Comments).FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(Post p)
        {
            try
            {
                var z = _appDbContext.Post.FirstOrDefault(x => x.Id == p.Id);

                z.Title = p.Title;
                z.Description = p.Description;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
