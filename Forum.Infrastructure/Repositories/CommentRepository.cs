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
    public class CommentRepository : ICommentRepository
    {
        private AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Comment c)
        {
            try
            {
                _appDbContext.Comment.Add(c);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Comment>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Comment);
        }

        public async Task<IEnumerable<Comment>> BrowseAllAsync(int postId)
        {
            return await Task.FromResult(_appDbContext.Comment.Include(c => c.Post).Include(c => c.User).Where(c => c.Post.Id == postId));
        }

        public async Task<IEnumerable<Comment>> BrowseAllAsyncByUser(string userId)
        {
            return await Task.FromResult(_appDbContext.Comment.Where(c => c.User.Id == userId));
        }

        public async Task DelAsync(Comment c)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Comment.FirstOrDefault(x => x.Id == c.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Comment> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Comment.Include(c => c.Post).Include(c => c.User).FirstOrDefault(c => c.Id == id));
        }

        public async Task UpdateAsync(Comment c)
        {
            try
            {
                var z = _appDbContext.Comment.Include(c => c.Post).Include(c => c.User).FirstOrDefault(x => x.Id == c.Id);

                z.Content = c.Content;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
