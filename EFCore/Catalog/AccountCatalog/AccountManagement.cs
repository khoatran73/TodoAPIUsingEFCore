using EFCore.Catalog.AccountCatalog.Dtos;
using EFCore.EF;
using EFCore.Models;

namespace EFCore.Catalog.AccountCatalog
{
    public class AccountManagement : IAccountManagement
    {
        private readonly TodoDbContext _context;
        public AccountManagement (TodoDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(AccountCreateRequest request)
        {
            var account = new Account()
            {
                AccountId = request.AccountId,
                Email = request.Email,
                Name = request.Name,
                Url = request.Url
            };

            _context.Accounts.Add(account);
            return await _context.SaveChangesAsync();
        }
    }
}
