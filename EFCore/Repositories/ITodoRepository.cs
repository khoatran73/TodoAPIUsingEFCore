using EFCore.Models;

namespace EFCore.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodoByAccountId(string AccountId);
        Task<int> CreateTodo(Todo request);
        Task<int> UpdateTodo(string TodoId, Todo request);
        Task<int> DeleteTodo(string TodoId);
        void Save();
    }
}
