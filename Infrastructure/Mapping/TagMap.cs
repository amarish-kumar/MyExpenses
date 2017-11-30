/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using MyExpenses.Domain.Models;

    internal static class TagMap
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(entity =>
            {
                // Primary key
                entity.HasKey(x => x.Id);

                // Columns
                entity.Property(x => x.Name).HasColumnName("Name");

                entity.ToTable("Tag");
            });
        }
    }
}
