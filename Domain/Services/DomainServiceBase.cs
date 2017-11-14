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
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Util.Results;

    public abstract class DomainService<TDomain> : IDomainService<TDomain> where TDomain : class, IDomain
    {
        private readonly IRepository<TDomain> _repository;

        protected DomainService(IRepository<TDomain> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter, params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.Get(filter, includes);
        }

        public IEnumerable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.GetAll(includes);
        }

        public TDomain GetById(long id, params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.GetById(id, includes);
        }

        public MyResults Remove(TDomain entity)
        {
            return _repository.Remove(entity);
        }

        public MyResults AddOrUpdate(TDomain entity)
        {
            return _repository.AddOrUpdate(entity);
        }
    }
}
