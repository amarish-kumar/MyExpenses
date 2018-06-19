/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MyExpenses.Domain.Interfaces;

    public abstract class ConfigurationBase<TModel> : IEntityTypeConfiguration<TModel> where TModel : class, IModel
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
        }
    }
}
