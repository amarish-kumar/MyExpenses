/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Util.Results;

    public abstract class AppServiceBase<TDomain, TDto> : IAppService<TDto>
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

        public virtual ICollection<TDto> GetAll()
        {
            // Get all from domain
            var domains = _domainService.GetAll();

            // Convert domain into dto
            var dtos = domains.Select(_adaper.ToDto).ToList();

            return dtos;
        }

        public virtual TDto GetById(long id)
        {
            // get domain class by id
            var domain = _domainService.GetById(id);

            // convert to dto
            return _adaper.ToDto(domain);
        }

        public virtual MyResults Remove(TDto dto)
        {
            // convert to domain
            var domain = _adaper.ToDomain(dto);

            _unitOfWork.BeginTransaction();

            // remove
            var results = _domainService.Remove(domain);

            if (results.Type == MyResultsType.Ok)
                _unitOfWork.Commit();

            return results;
        }

        public virtual MyResults AddOrUpdate(TDto dto)
        {
            // convert to domain
            var domain = _adaper.ToDomain(dto);

            _unitOfWork.BeginTransaction();

            // save and updates
            var results = _domainService.AddOrUpdate(domain);

            if (results.Type == MyResultsType.Ok)
                _unitOfWork.Commit();

            return results;
        }
    }
}
