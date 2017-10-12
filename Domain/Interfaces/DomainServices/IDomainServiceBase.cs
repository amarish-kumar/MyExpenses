/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using MyExpenses.CrossCutting.Results;

    public interface IDomainServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        MyResults SaveOrUpdate(TEntity entity);

        MyResults Remove(TEntity entity);
    }
}
