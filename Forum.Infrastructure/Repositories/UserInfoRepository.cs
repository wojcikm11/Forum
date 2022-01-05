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
    public class UserInfoRepository : IUserInfoRepository
    {
        private AppDbContext _appDbContext;

        public UserInfoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(UserInfo u)
        {
            try
            {
                _appDbContext.UserInfo.Add(u);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<UserInfo>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.UserInfo.Include(u => u.User).Include(u => u.UserId));
        }

        public async Task DelAsync(UserInfo u)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.UserInfo.FirstOrDefault(x => x.Id == u.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<UserInfo> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.UserInfo.Include(u => u.User).FirstOrDefault(u => u.Id == id));
        }

        public async Task UpdateAsync(UserInfo u)
        {
            try
            {
                var z = _appDbContext.UserInfo.Include(u => u.User).FirstOrDefault(x => x.Id == u.Id);

                z.FirstName = u.FirstName;
                z.LastName = u.LastName;
                z.Town = u.Town;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
