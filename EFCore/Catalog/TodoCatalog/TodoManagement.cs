using EFCore.Catalog.TodoCatalog.Dtos;
using EFCore.EF;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Todo>> GetTodoByAccountId(string AccountId)
        {
            var todoList = _context.Todos
                .Where(t => t.AccountId == AccountId)
                .ToList();

            return todoList;
        }

        public async Task<int> CreateTodo(TodoCreateRequest request)
        {
            var todo = new Todo()
            {
                TodoId = request.TodoId,
                AccountId = request.AccountId,
                Name = request.Name,
                IsCompleted = request.IsCompleted,
                Priority = request.Priority
            };

            _context.Todos.Add(todo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTodo(string TodoId, TodoCreateRequest request)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.TodoId == TodoId);

            if (todo == null) throw new Exception($"Cannot find a product with id: {TodoId}");

            todo.Priority = request.Priority;
            todo.Name = request.Name;
            todo.IsCompleted = request.IsCompleted;

            //_context.Todos.Update(todo);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTodo(string TodoId)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.TodoId == TodoId);

            if (todo == null) throw new Exception($"Cannot find a product with id: {TodoId}");

            _context.Todos.Remove(todo);

            return await _context.SaveChangesAsync();
        }
    }
}
