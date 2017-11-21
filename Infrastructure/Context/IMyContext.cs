/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using System.Data.Entity;

    using MyExpenses.Domain.Models;

    public interface IMyContext
    {
        /// <summary>
        /// Table of expenses
        /// </summary>
        DbSet<Expense> Expenses { get; set; }

        /// <summary>
        /// Table of tags
        /// </summary>
        DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// @see DbContext 
        /// </summary>
        /// <typeparam name="TDomain">@see DbContext</typeparam>
        /// <returns>@see DbContext</returns>
        DbSet<TDomain> Set<TDomain>() where TDomain : class;

        /// <summary>
        /// @see DbContext
        /// </summary>
        /// <returns>@see DbContext</returns>
        int SaveChanges();
    }
}
