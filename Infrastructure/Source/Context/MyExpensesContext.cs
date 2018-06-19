/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Configuration;

    public class MyExpensesContext : IdentityDbContext<User>
    {
        public MyExpensesContext (DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ExpenseConfiguration());
            builder.ApplyConfiguration(new LabelConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Label> Label { get; set; }

        public DbSet<Expense> Expense { get; set; }

        public DbSet<Payment> Payment { get; set; }
    }
}
