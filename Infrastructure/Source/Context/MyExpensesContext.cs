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

    public class MyExpensesContext : IdentityDbContext<User>
    {
        public MyExpensesContext (DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Label> Label { get; set; }

        public DbSet<Expense> Expense { get; set; }

        public DbSet<Payment> Payment { get; set; }
    }
}
