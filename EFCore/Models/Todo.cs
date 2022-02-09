using System.ComponentModel.DataAnnotations;

namespace EFCore.Models
{
    public class Todo
    {
        [Key]
        public string TodoId { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string AccountId { get; set; } // foreign key
    }
}
