using EFCore.Repositories;

namespace EFCore.EF
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository accountRepository { get;  }
        ITodoRepository todoRepository { get; }
        void Save();
    }
}
