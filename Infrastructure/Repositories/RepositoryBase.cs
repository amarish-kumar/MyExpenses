/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using MyExpenses.CrossCutting.Results;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Infrastructure.Context;

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
            {
                set = set.Include(include);
            }

            if (filter != null)
            {
                set = set?.Where(filter);
            }

            return set;
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>();

            foreach (var include in includes)
            { 
                set = set.Include(include);
            }

            return set;
        }

        public TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>().Where(x => (object)x.Id == (object)id);

            foreach (var include in includes)
            {
                set = set.Include(include);
            }

            return set.FirstOrDefault();
        }

        public MyResults Remove(TEntity entity)
        {
            string action = String.Format(RepoStrings.Action_Removing, entity.GetType().Name);
            TEntity existEntity = _context.Set<TEntity>().Find(entity.Id);
            if (existEntity == null)
            {
                return new MyResults(MyResultsType.Error, action, RepoStrings.Error_RemoveInvalidObject);
            }

            _context.Set<TEntity>().Remove(existEntity);
            return new MyResults(MyResultsType.Ok, action);
        }

        public MyResults SaveOrUpdate(TEntity entity)
        {
            // Update
            if (entity.Id > 0)
            {
                TEntity existEntity = _context.Set<TEntity>().Find(entity.Id);
                if (existEntity != null)
                {
                    existEntity.Copy(entity);
                    return new MyResults(MyResultsType.Ok, String.Format(RepoStrings.Action_Updating, entity.GetType().Name));
                }
            }

            // Save Add
            _context.Set<TEntity>().Add(entity);
            return new MyResults(MyResultsType.Ok, String.Format(RepoStrings.Action_Adding, entity.GetType().Name));
        }
    }
}
