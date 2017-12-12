/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Properties;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Util.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class AppServiceBase<TDomain, TDto> : IAppService<TDomain, TDto>
        where TDomain : IDomain
        where TDto : IDto
    {
        private readonly IDomainService<TDomain> _domainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdapter<TDomain, TDto> _adaper;

        protected AppServiceBase(
            IDomainService<TDomain> domainService,
            IUnitOfWork unitOfWork,
            IAdapter<TDomain, TDto> adaper)
        {
            _domainService = domainService;
            _unitOfWork = unitOfWork;
            _adaper = adaper;
        }

        public virtual ICollection<TDto> GetAll(params Expression<Func<TDomain, object>>[] includes)
        {
            // Get all from domain
            var domains = _domainService.GetAll(includes);

            // Convert domain into dto
            var dtos = domains.Select(_adaper.ToDto).ToList();

            return dtos;
        }

        public virtual ICollection<TDto> Get(Expression<Func<TDomain, bool>> filter, params Expression<Func<TDomain, object>>[] includes)
        {
            // Get all from domain
            var domains = _domainService.Get(filter, includes);

            // Convert domain into dto
            var dtos = domains.Select(_adaper.ToDto).ToList();

            return dtos;
        }

        public virtual TDto GetById(long id, params Expression<Func<TDomain, object>>[] includes)
        {
            // get domain class by id
            var domain = _domainService.GetById(id, includes);

            if (domain == null)
                return default(TDto);

            // convert to dto
            return _adaper.ToDto(domain);
        }

        public virtual MyResults Remove(TDto dto)
        {
            if(dto == null)
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Removing, Resources.Error_DomainNotFound);

            // convert to domain
            var domain = _adaper.ToDomain(dto);

            _unitOfWork.BeginTransaction();

            // remove
            var results = _domainService.Remove(domain);

            if (results.IsValid)
                _unitOfWork.Commit();

            return results;
        }

        public virtual MyResults Remove(ICollection<TDto> dtos)
        {
            MyResults results = new MyResults(MyResultsStatus.Ok, MyResultsAction.Removing);

            _unitOfWork.BeginTransaction();

            foreach (TDto dto in dtos)
            {
                if (dto == null)
                    return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, Resources.Error_DomainNotFound);

                // convert to domain
                var domain = _adaper.ToDomain(dto);

                results = _domainService.Remove(domain);

                if (results.Status == MyResultsStatus.Error)
                    return results;
            }

            if (results.IsValid)
                _unitOfWork.Commit();

            return results;
        }

        public virtual MyResults AddOrUpdate(TDto dto)
        {
            if (dto == null)
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, Resources.Error_DomainNotFound);

            // convert to domain
            var domain = _adaper.ToDomain(dto);

            _unitOfWork.BeginTransaction();

            // save and updates
            var results = _domainService.AddOrUpdate(domain);

            if (results.IsValid)
                _unitOfWork.Commit();

            return results;
        }

        public virtual MyResults AddOrUpdate(ICollection<TDto> dtos)
        {
            MyResults results = new MyResults(MyResultsStatus.Ok, MyResultsAction.Removing);

            _unitOfWork.BeginTransaction();

            foreach (TDto dto in dtos)
            {
                if (dto == null)
                    return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, Resources.Error_DomainNotFound);

                // convert to domain
                var domain = _adaper.ToDomain(dto);

                results = _domainService.AddOrUpdate(domain);

                if (!results.IsValid)
                    return results;
            }

            if (results.IsValid)
                _unitOfWork.Commit();

            return results;
        }
    }
}
