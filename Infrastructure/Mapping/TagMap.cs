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

    internal class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Columns
            builder.Property(x => x.Name).HasColumnName("Name");

            builder.ToTable("Tag");
        }
    }
}
