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

        public virtual IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter, params Expression<Func<TDomain, object>>[] includes)
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
            TDomain exisTDomain = _context.Set<TDomain>().Find(domain.Id);
            if (exisTDomain == null)
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Removing, MyResultsAction.Removing + " " + domain.GetType().Name);

            _context.Set<TDomain>().Remove(exisTDomain);
            _log?.AppendLog(LevelLog.Info, MyResultsAction.Removing + " " + domain.GetType().Name);
            return new MyResults(MyResultsStatus.Ok, MyResultsAction.Removing, domain.GetType().Name);
        }

        public virtual MyResults AddOrUpdate(TDomain domain)
        {
            MyResults validate = domain.Validate();
            if (validate.Status != MyResultsStatus.Ok)
                return validate;

            // Update
            if (domain.Id > 0)
            {
                TDomain existDomain = _context.Set<TDomain>().Find(domain.Id);
                if (existDomain == null)
                    return new MyResults(MyResultsStatus.Error, MyResultsAction.Updating, domain.GetType().Name);

                // copy attributes
                existDomain.Copy(domain);
                _log?.AppendLog(LevelLog.Info, MyResultsAction.Updating + " " + domain.GetType().Name);
                return new MyResults(MyResultsStatus.Ok, MyResultsAction.Updating, domain.GetType().Name);
            }

            // Save Add
            _context.Set<TDomain>().Add(domain);
            _log?.AppendLog(LevelLog.Info, MyResultsAction.Creating + " " + domain.GetType().Name);
            return new MyResults(MyResultsStatus.Ok, MyResultsAction.Creating, domain.GetType().Name);
        }
    }
}
