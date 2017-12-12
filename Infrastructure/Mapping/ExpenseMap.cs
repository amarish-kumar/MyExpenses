/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyExpenses.Domain.Models;

    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Columns
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Value).HasColumnName("Value");
            builder.Property(x => x.Date).HasColumnName("Data");

            // Relations
            builder.HasOne(x => x.Tag).WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Expense");
        }
    }
}
