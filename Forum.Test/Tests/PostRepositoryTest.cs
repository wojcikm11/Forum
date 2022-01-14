using Forum.Core.Domain;
using Forum.Core.Repository;
using Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Test.Tests
{
    [TestClass]
    public class PostRepositoryTest
    {
        private readonly IPostRepository _postRepository;
        private readonly Mock<IdentityDbContext<User>> _dbContextMock = new Mock<IdentityDbContext<User>>();
        private readonly Mock<DbSet<Post>> _dbSetMock = new Mock<DbSet<Post>>();


        public PostRepositoryTest()
        {
            _postRepository = new PostRepository((AppDbContext) _dbContextMock.Object);
        }

        [TestMethod]
        public async Task GetAsync_ShouldReturnPost_WhenPostExists()
        {
            //Setup DbContext and DbSet mock  
            _dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(new ValueTask<Post>(Task.FromResult(new Post())));
            _dbContextMock.Setup(s => s.Set<Post>()).Returns(_dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var post = await Task.FromResult(_postRepository.GetAsync(1));

            //Assert  
            Assert.IsNotNull(post);
        }
    }
}
