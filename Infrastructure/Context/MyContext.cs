/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using System.Data.Entity;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Mapping;

    public class MyContext : DbContext, IMyContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MyContext() : base("name=MyLocalDatabase")
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Table of expenses
        /// </summary>
        public IDbSet<Expense> Expenses { get; set; }

        /// <summary>
        /// Table of tags
        /// </summary>
        public IDbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Map all tables
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpenseMap());
            modelBuilder.Configurations.Add(new TagMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
