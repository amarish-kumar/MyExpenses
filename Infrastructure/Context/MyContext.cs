/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;
    using MyExpenses.Infrastructure.Mapping;

    public class MyContext : DbContext, IMyContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

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
