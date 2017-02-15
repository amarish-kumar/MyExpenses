namespace Domain.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IServiceBase<TEntity, TId>
    {
        TEntity GetById(TId id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(int page, params Expression<Func<TEntity, object>>[] includes);


        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(int page, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        void Remove(TEntity entity);

        void SaveOrUpdate(TEntity entity);

        void SaveOrUpdate(List<TEntity> entities);
    }
