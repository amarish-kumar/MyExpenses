/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Repositories
{
    using System;

    using Domain.Interfaces.Repositories;
    using Domain.Model;

    using Infrastructure.Context;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        private readonly MyContext _context;

        public RepositoryBase(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>();

            foreach (var include in includes)
                set = set.Include(include);

            if (filter != null)
                set = set?.Where(filter);

            return set;
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>().Where(x => (object)x.Id == (object)id);

            foreach (var include in includes)
                set = set.Include(include);

            return set.FirstOrDefault();
        }

        public TEntity Remove(TEntity entity)
        {
            TEntity set = _context.Set<TEntity>().Remove(entity);
            return set;
        }

        public TEntity SaveOrUpdate(TEntity entity)
        {
            // Update
            if (entity.Id > 0)
            {
                TEntity existEntity = _context.Set<TEntity>().Find(entity.Id);
                if (existEntity != null)
                {
                    existEntity.Copy(entity);
                    return existEntity;
                }
            }

            // Save Add
            return _context.Set<TEntity>().Add(entity);
        }
    }
}
