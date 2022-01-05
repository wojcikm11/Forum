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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task AddAsync(CreateComment c)
        {
            await _commentRepository.AddAsync(Map(c));
        }

        public async Task<IEnumerable<CommentDTO>> BrowseAllAsync()
        {
            var comments = await _commentRepository.BrowseAllAsync();
            return comments.Select(c => Map(c));
        }

        public async Task<IEnumerable<CommentDTO>> BrowseAllAsync(int postId)
        {
            var comments = await _commentRepository.BrowseAllAsync(postId);
            return comments.Select(c => Map(c));
        }

        public async Task DelAsync(int id)
        {
            var comment = _commentRepository.GetAsync(id).Result;
            await _commentRepository.DelAsync(comment);
        }

        public async Task<CommentDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_commentRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(int id, UpdateComment c)
        {
            await _commentRepository.UpdateAsync(Map(c, id));
        }

        private Comment Map(CreateComment c)
        {
            return new Comment()
            {
                User = _userRepository.GetAsync(c.UserId).Result,
                Post = _postRepository.GetAsync(int.Parse(c.PostId)).Result,
                Content = c.Comment,
                DateAdded = DateTime.Now
            };
        }

        private CommentDTO Map(Comment c)
        {
            return new CommentDTO()
            {
                Id = c.Id.ToString(),
                User = c.User.UserName,
                Comment = c.Content,
                DateAdded = c.DateAdded
            };
        }

        private Comment Map(UpdateComment c, int id)
        {
            var comment = _commentRepository.GetAsync(id).Result;
            return new Comment()
            {
                Id = id,
                User = comment.User,
                Post = comment.Post,
                Content = c.Comment,
                DateAdded = comment.DateAdded
            };
        }
    }
}
