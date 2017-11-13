/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using MyExpenses.Util.Results;

    public interface IDomainService<TEntity> where TEntity : IEntity
    {
        TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        MyResults SaveOrUpdate(TEntity entity);

        MyResults Remove(TEntity entity);
    }
}
