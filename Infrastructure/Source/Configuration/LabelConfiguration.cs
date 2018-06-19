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

    internal class LabelConfiguration : ConfigurationBase<Label>
    {
        public override void Configure(EntityTypeBuilder<Label> builder)
        {
            base.Configure(builder);

            // Columns
            builder.Property(x => x.Name).HasColumnName(Resource.ColumnName);
            builder.HasMany(x => x.Expenses).WithOne(x => x.Label).HasForeignKey(x => x.LabelId);

            builder.ToTable(Resource.LabelTable);
        }
    }
}
