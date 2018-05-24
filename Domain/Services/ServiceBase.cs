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
    using MyExpenses.Domain.Interfaces;

    public abstract class ServiceBase<TModel> : IService<TModel> where TModel : IModel
    {
        private readonly IService<TModel> _repository;

        protected ServiceBase(IService<TModel> repository)
        {
            _repository = repository;
        }

        public virtual TModel AddOrUpdate(TModel model)
        {
            return _repository.AddOrUpdate(model);
        }

        public virtual IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.GetAll(includes);
        }

        public virtual IEnumerable<TModel> Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.Get(filter, includes);
        }

        public virtual TModel GetById(long id, params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.GetById(id, includes);
        }

        public virtual bool Remove(long id)
        {
            return _repository.Remove(id);
        }
    }
}
