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
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("/comment/post/{id}")]
        public async Task<IActionResult> BrowseAllPostComments(int id)
        {
            var comments = await _commentService.BrowseAllAsync(id);
            return Json(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetAsync(id);
            return Json(comment);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody] CreateComment comment)
        {
            await _commentService.AddAsync(comment);
            return Created("", comment);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditComment([FromBody] UpdateComment comment, int id)
        {
            await _commentService.UpdateAsync(id, comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DelAsync(id);
            return NoContent();
        }
    }
}
