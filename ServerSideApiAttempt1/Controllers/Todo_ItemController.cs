using Microsoft.AspNetCore.Mvc;
using System;
using ServerSideApiAttempt1.Models;
using ServerSideApiAttempt1.Repositories;

namespace ServerSideApiAttempt1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo_ItemController : ControllerBase
    {
        private readonly ITodo_ItemRepository _todo_itemRepository;
        public Todo_ItemController(ITodo_ItemRepository todo_ItemRepository)
        {
            _todo_itemRepository = todo_ItemRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetTodo_ItemsByUserId(int userId)
        {
            return Ok(_todo_itemRepository.GetTodo_ItemsByUserId(userId));
        }
    }
}
