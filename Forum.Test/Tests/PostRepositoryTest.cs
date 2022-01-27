using Forum.Core.Domain;
using Forum.Core.Repository;
using Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Test.Tests
{
    [TestClass]
    public class PostRepositoryTest
    {
        private readonly IPostRepository _postRepository;
        private readonly Mock<AppDbContext> _dbContextMock = new Mock<AppDbContext>();
        private readonly Mock<DbSet<Post>> _dbSetMock = new Mock<DbSet<Post>>();


        public PostRepositoryTest()
        {
            _postRepository = new PostRepository(_dbContextMock.Object);
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

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdatePost_WhenPostExists()
        {
            //Setup DbContext and DbSet mock  
            _dbSetMock.Setup(s => s.Update(It.IsAny<Post>())).Verifiable();
            _dbContextMock.Setup(s => s.Set<Post>()).Returns(_dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var result = await Task.FromResult(_postRepository.UpdateAsync(new Post()));

            //Assert  
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AddAsync_ShouldAddPost()
        {
            //Setup DbContext and DbSet mock  

            _dbSetMock.Setup(s => s.Add(It.IsAny<Post>())).Verifiable();
            _dbContextMock.Setup(s => s.Set<Post>()).Returns(_dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var result = await Task.FromResult(_postRepository.AddAsync(new Post()));

            //Assert  
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldDeletePost_WhenPostExists()
        {
            //Setup DbContext and DbSet mock  

            _dbSetMock.Setup(s => s.Remove(It.IsAny<Post>())).Verifiable();
            _dbContextMock.Setup(s => s.Set<Post>()).Returns(_dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var result = await Task.FromResult(_postRepository.DelAsync(new Post()));

            //Assert  
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindAllAsync_ShouldReturnPostList()
        {
            //Setup DbContext and DbSet mock  

            _dbSetMock.Setup(s => s.AsAsyncEnumerable()).Verifiable();
            _dbContextMock.Setup(s => s.Set<Post>()).Returns(_dbSetMock.Object).Verifiable();

            //Execute method of SUT (ProductsRepository)  
            var postsList = await Task.FromResult(_postRepository.BrowseAllAsync());

            //Assert  
            Assert.IsNotNull(postsList);
        }
    }
}
