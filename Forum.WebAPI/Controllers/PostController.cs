using Forum.Infrastructure.Commands;
using Forum.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var posts = await _postService.BrowseAll();
            return Json(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetAsync(id);
            return Json(post);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost([FromBody] CreatePost post)
        {
            await _postService.AddAsync(post);
            return Created("", post);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditPost([FromBody] UpdatePost post, int id)
        {
            await _postService.UpdateAsync(id, post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DelAsync(id);
            return NoContent();
        }

        [HttpGet("/postlist")]
        public async Task<IActionResult> GetPostList()
        {
            var posts = await _postService.GetPostList();
            return Json(posts);
        }
    }
}
