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

        public virtual TModel Add(TModel model)
        {
            return _repository.Add(model);
        }

        public virtual TModel Update(TModel model)
        {
            return _repository.Update(model);
        }

        public virtual IEnumerable<TModel> Get(params Expression<Func<TModel, object>>[] includes)
        {
            return _repository.Get(includes);
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
