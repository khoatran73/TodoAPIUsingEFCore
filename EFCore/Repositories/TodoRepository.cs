using EFCore.EF;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTodo(string TodoId)
        {
            var todo = (from t in _context.Todos where t.TodoId == TodoId select t).FirstOrDefault();

            if (todo != null)
                _context.Todos.Remove(todo);
            else
                throw new Exception($"Cannot find a product with id: {TodoId}");

            return await _context.SaveChangesAsync();
        }

        public IEnumerable<Todo> GetTodoByAccountId(string AccountId)
        {
            return _context.Todos
                .Where(t => t.AccountId == AccountId)
                .ToList();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTodo(string TodoId, Todo todo)
        {
            var _todo = await _context.Todos.FirstOrDefaultAsync(t => t.TodoId == TodoId);

            if (_todo == null) throw new Exception($"Cannot find a product with id: {TodoId}");

            _todo.Priority = todo.Priority;
            _todo.Name = todo.Name;
            _todo.IsCompleted = todo.IsCompleted;

            return await _context.SaveChangesAsync();
        }
    }
}
