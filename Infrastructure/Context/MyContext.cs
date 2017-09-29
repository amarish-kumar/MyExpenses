namespace Infrastructure.Context
{
    using System.Data.Common;
    using System.Data.Entity;

    using Domain.Model;

    using Infrastructure.Mapping;

    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpenseMap());
        }
    }
}
