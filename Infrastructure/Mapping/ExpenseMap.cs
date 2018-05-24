/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

//namespace MyExpenses.Infrastructure.Mapping
//{
//    using Microsoft.EntityFrameworkCore;

//    using MyExpenses.Domain.Models;

//    // reference: https://msdn.microsoft.com/en-us/library/jj591617%28v=vs.113%29.aspx?f=255&MSPPError=-2147217396
//    public static class ExpenseMap
//    {
//        public static void Map(ModelBuilder builder)
//        {
//            builder.Entity<Expense>().HasKey(x => x.Id);

//            builder.Entity<Expense>().Property(x => x.Name).HasColumnName("Name");
//            builder.Entity<Expense>().Property(x => x.Value).HasColumnName("Value");
//            builder.Entity<Expense>().Property(x => x.Data).HasColumnName("Data");
//            builder.Entity<Expense>().Property(x => x.IsIncoming).HasColumnName("IsIncoming");
//            builder.Entity<Expense>().HasOne(x => x.Label);
//            builder.Entity<Expense>().HasOne(x => x.Payment);

//            builder.Entity<Expense>().ToTable("Expense");
//        }
//    }
//}
