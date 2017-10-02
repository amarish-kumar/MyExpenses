/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity SaveOrUpdate(TEntity entity);

        TEntity Remove(TEntity entity);
    }
}
