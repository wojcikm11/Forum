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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var users = await _userService.BrowseAll();
            return Json(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userService.GetAsync(id);
            return Json(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUser([FromBody] CreateUser user)
        {
            await _userService.AddAsync(user);
            return Created("", user);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditUser([FromBody] UpdateUser user, string id)
        {
            await _userService.UpdateAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DelAsync(id);
            return NoContent();
        }
    }
}
