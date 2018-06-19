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

    internal class PaymentConfiguration : ConfigurationBase<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName(Resource.ColumnName);
            builder.HasMany(x => x.Expenses).WithOne(x => x.Payment).HasForeignKey(x => x.PaymentId);

            builder.ToTable(Resource.PaymentTable);
        }
    }
}
