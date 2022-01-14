using Forum.Core.Domain;
using Forum.Core.Repository;
using Forum.Infrastructure.Commands;
using Forum.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task AddAsync(CreatePost p)
        {
            await _postRepository.AddAsync(Map(p));
        }

        public async Task<IEnumerable<PostDTO>> BrowseAll()
        {
            var posts = await _postRepository.BrowseAllAsync();
            return posts.Select(p => Map(p));
        }

        public async Task DelAsync(int id)
        {
            var post = _postRepository.GetAsync(id).Result;
            await _postRepository.DelAsync(post);
        }

        public async Task<PostDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_postRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(int id, UpdatePost p)
        {
            await _postRepository.UpdateAsync(Map(p, id));
        }

        public async Task<PostListDTO> GetPostList()
        {
            var posts = await _postRepository.BrowseAllAsync();
            var postsDTO = posts.Select(p => Map(p));
            int recentPosts = getRecentPosts(postsDTO);
            return await Task.FromResult(new PostListDTO(){ Posts = postsDTO.ToList(), RecentPosts = recentPosts });
        }

        private int getRecentPosts(IEnumerable<PostDTO> postsDTO)
        {
            int days = 7;
            return postsDTO.Where(post => (DateTime.Now - post.DatePosted).TotalDays <= days).Count();
        }

        private Post Map(CreatePost p)
        {
            return new Post()
            {
                Author = _userRepository.GetAsync(p.AuthorId).Result,
                Title = p.Title,
                Description = p.Description,
                DatePosted = DateTime.Now
            };
        }

        private PostDTO Map(Post p)
        {
            return new PostDTO()
            {
                Id = p.Id,
                Author = p.Author.UserName,
                Title = p.Title,
                Description = p.Description,
                DatePosted = p.DatePosted
            };
        }

        private Post Map(UpdatePost updatePost, int id)
        {
            var post = _postRepository.GetAsync(id).Result;
            return new Post()
            {
                Id = id,
                Author = post.Author,
                Title = updatePost.Title,
                Description = updatePost.Description,
                DatePosted = post.DatePosted,
                Comments = post.Comments
            };
        }
    }
}
