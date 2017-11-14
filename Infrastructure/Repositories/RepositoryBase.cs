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
    using MyExpenses.Util.Logger;
    using MyExpenses.Util.Results;

    public abstract class Repository<TDomain>: IRepository<TDomain> where TDomain : class, IDomain
    {
        private readonly IMyContext _context;
        private readonly ILogService _log;

        protected  Repository(IMyContext context, ILogService log)
        {
            _context = context;
            _log = log;
        }

        public virtual void UpdateDependencies(TDomain entity) { }

        public virtual IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter = null, params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> set = _context.Set<TDomain>();

            foreach (var include in includes)
                set = set.Include(include);

            if (filter != null)
                set = set?.Where(filter);

            return set;
        }

        public virtual IEnumerable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> set = _context.Set<TDomain>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual TDomain GetById(long id, params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> set = _context.Set<TDomain>().Where(x => x.Id == id);

            foreach (var include in includes)
                set = set.Include(include);

            return set.FirstOrDefault();
        }

        public virtual MyResults Remove(TDomain domain)
        {
            string action = string.Format(Resources.Action_Removing, domain.GetType().Name);
            TDomain exisTDomain = _context.Set<TDomain>().Find(domain.Id);
            if (exisTDomain == null)
            {
                return new MyResults(MyResultsType.Error, action, Resources.Error_RemoveInvalidObject);
            }

            _context.Set<TDomain>().Remove(exisTDomain);
            _log?.AppendLog(LevelLog.Info, action);
            return new MyResults(MyResultsType.Ok, action);
        }

        public virtual MyResults AddOrUpdate(TDomain domain)
        {
            MyResults validate = (domain as IDomain).Validate();
            if (validate.Type != MyResultsType.Ok)
                return validate;

            // Update
            if (domain.Id > 0)
            {
                TDomain exisTDomain = _context.Set<TDomain>().Find(domain.Id);
                if (exisTDomain != null)
                {
                    exisTDomain.Copy(domain);
                    _log?.AppendLog(LevelLog.Info, String.Format(Resources.Action_Updating, domain.GetType().Name));
                    return new MyResults(MyResultsType.Ok, String.Format(Resources.Action_Updating, domain.GetType().Name));
                }
            }

            // Save Add
            _context.Set<TDomain>().Add(domain);
            _log?.AppendLog(LevelLog.Info, String.Format(Resources.Action_Adding, domain.GetType().Name));
            return new MyResults(MyResultsType.Ok, String.Format(Resources.Action_Adding, domain.GetType().Name));
        }
    }
}
