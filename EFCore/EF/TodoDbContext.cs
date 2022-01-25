using EFCore.Configuration;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.EF
{
    public class TodoDbContext : DbContext
    {        
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TodoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
