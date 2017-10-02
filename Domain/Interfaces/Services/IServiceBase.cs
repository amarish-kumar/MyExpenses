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

    public interface IServiceBase<TEntity>
    {
        TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(int page, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(int page, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        void Remove(TEntity entity);

        bool SaveOrUpdate(TEntity entity);

        bool SaveOrUpdate(List<TEntity> entities);
    }
}
