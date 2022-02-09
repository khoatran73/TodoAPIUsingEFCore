using EFCore.Models;
using EFCore.Repositories;

namespace EFCore.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _context;
        public IAccountRepository accountRepository { get; }

        public ITodoRepository todoRepository { get; }

        public UnitOfWork(TodoDbContext context)
        {
            _context = context;
            accountRepository = new AccountRepository(_context);
            todoRepository = new TodoRepository(_context);

        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
