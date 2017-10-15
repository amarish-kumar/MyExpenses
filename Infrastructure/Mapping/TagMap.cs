/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using MyExpenses.Domain.Models;

    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("Name");

            ToTable("Tags");
        }
    }
}
