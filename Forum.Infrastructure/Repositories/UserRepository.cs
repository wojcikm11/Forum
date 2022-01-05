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
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(User u)
        {
            try
            {
                _appDbContext.User.Add(u);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<User>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.User.Include(u => u.UserInfo).Include(u => u.UserPosts).Include(u => u.UserComments));
        }

        public async Task DelAsync(User u)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.User.FirstOrDefault(x => x.Id == u.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<User> GetAsync(string id)
        {
            return await Task.FromResult(_appDbContext.User.Include(u => u.UserInfo).Include(u => u.UserPosts).Include(u => u.UserComments).FirstOrDefault(u => u.Id == id));
        }

        public async Task<User> GetAsyncByInfoId(int id)
        {
            return await Task.FromResult(_appDbContext.User.Include(u => u.UserInfo).Include(u => u.UserPosts).Include(u => u.UserComments).FirstOrDefault(u => u.UserInfo.Id == id));
        }

        public async Task UpdateAsync(User u)
        {
            try
            {
                var z = _appDbContext.User.Include(u => u.UserInfo).Include(u => u.UserPosts).Include(u => u.UserComments).FirstOrDefault(x => x.Id == u.Id);

                z.UserName = u.UserName;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
