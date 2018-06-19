/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Properties;

    internal class ExpenseConfiguration : ConfigurationBase<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Name).HasColumnName(Resource.ColumnName);
            builder.Property(x => x.Value).HasColumnName(Resource.ColumnValue);
            builder.Property(x => x.Data).HasColumnName(Resource.ColumnDate);
            builder.Property(x => x.Incoming).HasColumnName(Resource.ColumnIncoming);
            builder.HasOne(x => x.Label).WithMany(x => x.Expenses).HasForeignKey(x => x.LabelId);
            builder.HasOne(x => x.Payment).WithMany(x => x.Expenses).HasForeignKey(x => x.PaymentId);
            builder.Ignore(x => x.IsIncoming);

            builder.ToTable(Resource.ExpenseTable);
        }
    }
}
