using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Model;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            await _itemService.CreateAsync(item);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            var Items = await _itemService.GetAllAsync();
            return Ok(Items);
        }

        [HttpGet("GetByUserID")]
        public async Task<ActionResult<IEnumerable<Item>>> GetByUserID(string userid)
        {
            var Items = await _itemService.GetByUser(userid);
            return Ok(Items);
        }

        [HttpGet("GetByCategory")]
        public async Task<ActionResult<IEnumerable<Item>>> GetByCategory(string category)
        {
            var Items = await _itemService.GetByCategory(category);
            return Ok(Items);
        }

        
    }
}
