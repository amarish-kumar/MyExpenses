/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using MyExpenses.Util.Results;

    public interface IRepository<TDomain> where TDomain : class
    {
        TDomain GetById(long id, params Expression<Func<TDomain, object>>[] includes);

        IEnumerable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes);

        IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter, params Expression<Func<TDomain, object>>[] includes);

        MyResults SaveOrUpdate(TDomain entity);

        MyResults Remove(TDomain entity);
    }
}
