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
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Interfaces;

    public class RepositoryBase<TModel> : IRepository<TModel> where TModel : class, IModel
    {
        private readonly MyExpensesContext _context;

        public RepositoryBase(MyExpensesContext context)
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

        public virtual async Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            if (filter != null)
                set = set?.Where(filter);

            return await set.ToArrayAsync();
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync(params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return await set.ToArrayAsync();
        }

        public virtual async Task<TModel> GetByIdAsync(long id, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return await set.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> RemoveAsync(TModel model)
        {
            return await RemoveAsync(model.Id);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            TModel model = await _context.Set<TModel>().FindAsync(id);
            if (model == null)
                return false;

            _context.Set<TModel>().Remove(model);

            return true;
        }

        public async Task<TModel> AddOrUpdateAsync(TModel model)
        {
            // Update
            if (model.Id > 0)
            {
                TModel existModel = await _context.Set<TModel>().FindAsync(model.Id);
                if (existModel == null)
                    return null;

                // copy attributes
                existModel.Copy(model);
                return existModel;
            }

            // Save Add
            EntityEntry<TModel> addModel = await _context.Set<TModel>().AddAsync(model);
            return addModel.Entity;
        }
    }
}
