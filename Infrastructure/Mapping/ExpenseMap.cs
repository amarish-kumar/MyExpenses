/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using MyExpenses.Domain.Models;

    public class ExpenseMap : EntityTypeConfiguration<Expense>
    {
        public ExpenseMap()
        {
            // Primary key
            HasKey(x => x.Id);

            // Columns
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Value).HasColumnName("Value");
            Property(x => x.Date).HasColumnName("Data");

            // Relations
            HasMany(e => e.Tags)
                .WithMany()
                .Map(m => m.ToTable("Expenses_Tags").MapLeftKey("ExpenseId").MapRightKey("TagId"));

            ToTable("Expenses");
        }
    }
}
