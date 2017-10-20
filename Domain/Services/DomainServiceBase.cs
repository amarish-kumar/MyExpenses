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

    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        protected DomainServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Get(filter, includes);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetAll(includes);
        }

        public TEntity GetById(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetById(id, includes);
        }

        public MyResults Remove(TEntity entity)
        {
            return _repository.Remove(entity);
        }

        public MyResults SaveOrUpdate(TEntity entity)
        {
            return _repository.SaveOrUpdate(entity);
        }
    }
}
