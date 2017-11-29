/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Mapping;

    public class MyContext : DbContext, IMyContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        /// <summary>
        /// Table of expenses
        /// </summary>
        public DbSet<Expense> Expenses { get; set; }

        /// <summary>
        /// Table of tags
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Map all tables
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ExpenseMap.Map(modelBuilder);
            TagMap.Map(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
