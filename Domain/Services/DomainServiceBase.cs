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

        protected DomainService(IRepository<TDomain> repository) => _repository = repository;

        public virtual IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter, params Expression<Func<TDomain, object>>[] includes) => _repository.Get(filter, includes);

        public virtual IEnumerable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes) => _repository.GetAll(includes);

        public virtual TDomain GetById(long id, params Expression<Func<TDomain, object>>[] includes) => _repository.GetById(id, includes);

        public virtual MyResults Remove(TDomain domain) => _repository.Remove(domain);

        public MyResults AddOrUpdate(TDomain domain) => _repository.AddOrUpdate(domain);
    }
}
