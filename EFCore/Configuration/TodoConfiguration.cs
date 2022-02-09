using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todo");

            builder.HasKey(todo => todo.TodoId);

            builder.HasOne<Account>()
                .WithMany()
                .HasForeignKey("AccountId");
        }
    }
}
