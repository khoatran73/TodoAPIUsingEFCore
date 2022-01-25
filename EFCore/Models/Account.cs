using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        //public List<Todo> Todos { get; set; }
    }
}
