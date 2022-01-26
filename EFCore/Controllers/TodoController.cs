using EFCore.Catalog.TodoCatalog;
using EFCore.Catalog.TodoCatalog.Dtos;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoManagement _iTodoManagement;

        public TodoController(ITodoManagement iTodoManagement)
        {
            _iTodoManagement = iTodoManagement;
        }

        [HttpGet]
        [Route("api/todo/{AccountId}")]
        public IActionResult GetTodoByAccountId(string AccountId)
        {
            var todoList = _iTodoManagement.GetTodoByAccountId(AccountId);

            return Ok(todoList.Result);
        }

        [HttpPost]
        [Route("api/todo")]
        public async Task<IActionResult> Create([FromBody] TodoCreateRequest request)
        {
            var result = await _iTodoManagement.CreateTodo(request);

            if (result == 0)
                return BadRequest("Cant not create todo");

            return Ok(result);
        }

        [HttpPut]
        [Route("api/todo/{TodoId}")]
        public async Task<IActionResult> UpdateTodo(string TodoId, [FromBody] TodoCreateRequest request)
        {
            var result = await _iTodoManagement.UpdateTodo(TodoId, request);

            if (result == 0)
                return BadRequest("Cant not update todo");

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/todo/{TodoId}")]
        public async Task<IActionResult> DeleteTodo(string TodoId)
        {
            var result = await _iTodoManagement.DeleteTodo(TodoId);

            if (result == 0)
                return BadRequest("Cant not delete todo");

            return Ok(result);
        }
    }
}
