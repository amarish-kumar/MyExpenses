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

    public static class LabelMap
    {
        public static void Map(ModelBuilder builder)
        {
            builder.Entity<Label>().ToTable("Label").HasKey(x => x.Id);
        }
    }

    internal class LabelMap1 : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Columns
            builder.Property(x => x.Name).HasColumnName("Name");

            builder.ToTable("Label");
        }
    }
}
