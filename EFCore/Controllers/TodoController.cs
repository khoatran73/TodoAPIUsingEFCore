using EFCore.EF;
using EFCore.Models;
using EFCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        //private IUnitOfWork _unitOfWork;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        [Route("api/todo/{AccountId}")]
        public async Task<IActionResult> GetTodoByAccountId(string AccountId)
        {
            var todoList = _todoRepository.GetTodoByAccountId(AccountId);

            return Ok(todoList);
        }

        [HttpPost]
        [Route("api/todo")]
        public async Task<IActionResult> Create([FromBody] Todo todo)
        {
            var result = await _todoRepository.CreateTodo(todo);

            if (result == 0)
                return BadRequest("Cant not create todo");

            return Ok(result);
        }

        [HttpPut]
        [Route("api/todo/{TodoId}")]
        public async Task<IActionResult> UpdateTodo(string TodoId, [FromBody] Todo todo)
        {
            var result = await _todoRepository.UpdateTodo(TodoId, todo);

            if (result == 0)
                return BadRequest("Cant not update todo");

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/todo/{TodoId}")]
        public async Task<IActionResult> DeleteTodo(string TodoId)
        {
            var result = await _todoRepository.DeleteTodo(TodoId);

            if (result == 0)
                return BadRequest("Cant not delete todo");

            return Ok(result);
        }
    }
}
