/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using System.Data.Entity;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Mapping;

    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyContext")
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpenseMap());
            modelBuilder.Configurations.Add(new TagMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
