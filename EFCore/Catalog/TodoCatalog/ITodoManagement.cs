using EFCore.Catalog.TodoCatalog.Dtos;
using EFCore.Models;

namespace EFCore.Catalog.TodoCatalog
{
    public interface ITodoManagement
    {
        Task<List<Todo>> GetTodoByAccountId(GetTodoByAccountIdRequest request);
    }
}
