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
        IDbSet<Expense> Expenses { get; set; }

        /// <summary>
        /// Table of tags
        /// </summary>
        IDbSet<Tag> Tags { get; set; }

        /// <summary>
        /// @see DbContext 
        /// </summary>
        /// <typeparam name="TEntity">@see DbContext</typeparam>
        /// <returns>@see DbContext</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// @see DbContext
        /// </summary>
        /// <returns>@see DbContext</returns>
        int SaveChanges();
    }
}
