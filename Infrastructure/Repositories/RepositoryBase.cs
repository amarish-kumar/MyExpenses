/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Properties;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Logger;
    using MyExpenses.Util.Results;

    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IDomain
    {
        private readonly IMyContext _context;
        private readonly ILogService _log;

        protected  Repository(IMyContext context, ILogService log)
        {
            _context = context;
            _log = log;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>();

            foreach (var include in includes)
                set = set.Include(include);

            if (filter != null)
                set = set?.Where(filter);

            return set;
        }

        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> set = _context.Set<TEntity>().Where(x => x.Id == id);

            foreach (var include in includes)
                set = set.Include(include);

            return set.FirstOrDefault();
        }

        public virtual MyResults Remove(TEntity entity)
        {
            string action = string.Format(Resources.Action_Removing, entity.GetType().Name);
            TEntity existEntity = _context.Set<TEntity>().Find(entity.Id);
            if (existEntity == null)
            {
                return new MyResults(MyResultsType.Error, action, Resources.Error_RemoveInvalidObject);
            }

            _context.Set<TEntity>().Remove(existEntity);
            _log?.AppendLog(LevelLog.Info, action);
            return new MyResults(MyResultsType.Ok, action);
        }

        public virtual MyResults SaveOrUpdate(TEntity entity)
        {
            MyResults validate = (entity as IDomain).Validate();
            if (validate.Type != MyResultsType.Ok)
                return validate;

            // Update
            if (entity.Id > 0)
            {
                TEntity existEntity = _context.Set<TEntity>().Find(entity.Id);
                if (existEntity != null)
                {
                    existEntity.Copy(entity);
                    _log?.AppendLog(LevelLog.Info, String.Format(Resources.Action_Updating, entity.GetType().Name));
                    return new MyResults(MyResultsType.Ok, String.Format(Resources.Action_Updating, entity.GetType().Name));
                }
            }

            // Save Add
            _context.Set<TEntity>().Add(entity);
            _log?.AppendLog(LevelLog.Info, String.Format(Resources.Action_Adding, entity.GetType().Name));
            return new MyResults(MyResultsType.Ok, String.Format(Resources.Action_Adding, entity.GetType().Name));
        }
    }
}
