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
    public class UserInfoController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoController(IUserInfoService userInfoServiceervice)
        {
            _userInfoService = userInfoServiceervice;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var usersInfo = await _userInfoService.BrowseAll();
            return Json(usersInfo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            var userInfo = await _userInfoService.GetAsync(id);
            return Json(userInfo);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserInfo([FromBody] CreateUserInfo userInfo)
        {
            await _userInfoService.AddAsync(userInfo);
            return Created("", userInfo);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditUserInfo([FromBody] UpdateUserInfo userInfo, int id)
        {
            await _userInfoService.UpdateAsync(id, userInfo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            await _userInfoService.DelAsync(id);
            return NoContent();
        }
    }
}
