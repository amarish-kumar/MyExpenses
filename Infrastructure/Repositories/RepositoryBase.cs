/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;

    public abstract class RepositoryBase<TModel> : IService<TModel> where TModel : class, IModel
    {
        private readonly MyExpensesContext _context;

        protected RepositoryBase(MyExpensesContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TModel> Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            if (filter != null)
                set = set?.Where(filter);

            return set;
        }

        public virtual IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual TModel GetById(long id, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return set.SingleOrDefault(x => x.Id == id);
        }

        public bool Remove(TModel model)
        {
            return Remove(model.Id);
        }

        public bool Remove(long id)
        {
            TModel model = _context.Set<TModel>().Find(id);
            if (model == null)
                return false;

            _context.Set<TModel>().Remove(model);

            return true;
        }

        public TModel AddOrUpdate(TModel model)
        {
            // Update
            if (model.Id > 0)
            {
                TModel existModel = _context.Set<TModel>().Find(model.Id);
                if (existModel == null)
                    return null;

                // copy attributes
                existModel.Copy(model);
                return existModel;
            }

            // Add
            var newModel = _context.Set<TModel>().Add(model);
            return newModel?.Entity;
        }
    }
}
