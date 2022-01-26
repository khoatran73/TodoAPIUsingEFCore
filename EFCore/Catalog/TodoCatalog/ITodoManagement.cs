using EFCore.Catalog.TodoCatalog.Dtos;
using EFCore.Models;

namespace EFCore.Catalog.TodoCatalog
{
    public interface ITodoManagement
    {
        Task<List<Todo>> GetTodoByAccountId(string AccountId);
        Task<int> CreateTodo(TodoCreateRequest request);
        Task<int> UpdateTodo(string TodoId, TodoCreateRequest request);
        Task<int> DeleteTodo(string TodoId);
    } 
}
