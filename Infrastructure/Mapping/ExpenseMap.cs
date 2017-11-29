/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Mapping
{
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Models;

    public static class ExpenseMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(entity =>
            {
                // Primary key
                entity.HasKey(x => x.Id);

                // Columns
                entity.Property(x => x.Name).HasColumnName("Name");
                entity.Property(x => x.Value).HasColumnName("Value");
                entity.Property(x => x.Date).HasColumnName("Data");

                entity.HasOne(x => x.Tag).WithOne().HasForeignKey<Expense>(y => y.TagId);

                entity.ToTable("Expense");
            });
        }
    }
}
