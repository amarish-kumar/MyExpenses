/* 
*   Project: MyBaseSolution
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
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Value).HasColumnName("Value");
            Property(x => x.Date).HasColumnName("Date");

            ToTable("Expenses");
        }
    }
}
