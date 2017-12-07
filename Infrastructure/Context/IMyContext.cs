/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;

    public interface IMyContext
    {
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
