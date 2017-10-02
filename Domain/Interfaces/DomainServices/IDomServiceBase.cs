/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Domain.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using MyExpenses.CrossCutting.Results;

    public interface IDomServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        MyResults SaveOrUpdate(TEntity entity);

        MyResults Remove(TEntity entity);
    }
}
