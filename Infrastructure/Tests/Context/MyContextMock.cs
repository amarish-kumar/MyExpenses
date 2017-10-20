/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Context
{
    using System.Data.Entity;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;

    public class MyContextMock : IMyContext
    {
        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        DbSet<TEntity> IMyContext.Set<TEntity>()
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
