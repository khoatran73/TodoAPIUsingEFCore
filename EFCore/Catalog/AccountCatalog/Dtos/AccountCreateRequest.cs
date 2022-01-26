namespace EFCore.Catalog.AccountCatalog.Dtos
{
    public class AccountCreateRequest
    {
        public string AccountId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
