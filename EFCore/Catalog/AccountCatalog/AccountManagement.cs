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
        public async Task<int> Create(AccountCreateRequest ACRequest)
        {
            var account = new Account()
            {
                AccountId = ACRequest.AccountId,
                Email = ACRequest.Email,
                Name = ACRequest.Name,
                Url = ACRequest.Url
            };

            _context.Accounts.Add(account);
            return await _context.SaveChangesAsync();
        }
    }
}
