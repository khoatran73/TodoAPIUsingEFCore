namespace EFCore.Catalog.TodoCatalog.Dtos
{
    public class TodoCreateRequest
    {
        public string TodoId { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string AccountId { get; set; }
    }
}
