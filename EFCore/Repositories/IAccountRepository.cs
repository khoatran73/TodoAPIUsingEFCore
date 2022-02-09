using EFCore.Models;

namespace EFCore.Repositories
{
    public interface IAccountRepository : IDisposable
    {
        Task<int> Create(Account account);

        void Save();
    }
}
