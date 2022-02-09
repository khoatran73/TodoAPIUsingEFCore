using EFCore.EF;
using EFCore.Models;

namespace EFCore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TodoDbContext _context;
        public AccountRepository(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Account account)
        {
            var isExists = (from a in _context.Accounts 
                            where a.AccountId == account.AccountId 
                            select a).FirstOrDefault();
            if (isExists == null)
            {
                _context.Accounts.Add(account);
            }
            
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
