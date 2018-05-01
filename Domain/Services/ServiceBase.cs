/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MyExpenses.Domain.Interfaces;

    public abstract class ServiceBase<TModel> : IService<TModel> where TModel : IModel
    {
        private readonly IService<TModel> _repository;

        protected ServiceBase(IService<TModel> repository)
        {
            _repository = repository;
        }

        public virtual Task<TModel> AddOrUpdateAsync(TModel model)
        {
            return _repository.AddOrUpdateAsync(model);
        }

        public virtual Task<IEnumerable<TModel>> GetAllAsync(params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.GetAllAsync(includes);
        }

        public virtual Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.GetAsync(filter, includes);
        }

        public virtual Task<TModel> GetByIdAsync(long id, params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.GetByIdAsync(id, includes);
        }

        public virtual Task<bool> RemoveAsync(TModel model)
        {
            return _repository.RemoveAsync(model);
        }

        public virtual Task<bool> RemoveAsync(long id)
        {
            return _repository.RemoveAsync(id);
        }
    }
}
