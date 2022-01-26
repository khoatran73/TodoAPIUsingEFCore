using EFCore.Catalog.TodoCatalog.Dtos;
using EFCore.EF;
using EFCore.Models;

namespace EFCore.Catalog.TodoCatalog
{
    public class TodoManagement : ITodoManagement
    {
        private readonly TodoDbContext _context;
        public TodoManagement(TodoDbContext context)
        {
            _context = context;
        }

        public TodoDbContext Get_context()
        {
            return _context;
        }

        public async Task<List<Todo>> GetTodoByAccountId(GetTodoByAccountIdRequest request)
        {
            var products = _context.Todos
                .Where(t => t.AccountId == request.AccountId)
                .ToList();

            return products;
        }
    }
}
