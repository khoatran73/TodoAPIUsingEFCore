using EFCore.Catalog.TodoCatalog;
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
            return Ok("ok");
        }
    }
}
