using EFCore.Catalog.AccountCatalog.Dtos;

namespace EFCore.Catalog.AccountCatalog
{
    public interface IAccountManagement
    {
        Task<int> Create(AccountCreateRequest ACRequest);
    }
}
