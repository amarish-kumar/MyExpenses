/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using Domain.Model;

    public class ExpenseMap : EntityTypeConfiguration<Expense>
    {
        public ExpenseMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("NAME");
            Property(x => x.Value).HasColumnName("VALUE");
            Property(x => x.Date).HasColumnName("DATE");

            // TODO - add many to many
            //HasRequired(x => x.Tags)
            //    .WithMany()
            //    .Map(m => m.MapKey("ID"));

            ToTable("EXPENSE");
        }
    }
}
