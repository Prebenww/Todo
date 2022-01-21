using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Model;
using ToDoAPI.Services;
using ToDoAPI.ViewModwl;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var Users = await _userService.GetAllAsync();
            return Ok(Users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateAsync(user);
            return Ok(user);
        }

        [HttpGet("GetUserForDropdown")]
        public async Task<ActionResult<IEnumerable<UserDropDownViewModel>>> GetUserForDropdown()
        {
            var UserDropDownViewModel = await _userService.GetAllAsync();
            return Ok(UserDropDownViewModel.Select(x=> new { id=x.Id,name=x.name }));
        }


       
    }
}
