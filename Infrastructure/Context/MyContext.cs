/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Context
{
    using System.Data.Entity;

    using Domain.Model;

    using Infrastructure.Mapping;

    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyLocalDatabaseConnectionString")
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpenseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
