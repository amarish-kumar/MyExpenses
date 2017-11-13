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
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Util.Results;

    public abstract class AppServiceBase<TEntity, TDto> : IAppService<TDto>
        where TEntity : IDomain
        where TDto : IDto
    {
        private readonly IDomainService<TEntity> _domainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdapter<TEntity, TDto> _adaper;

        protected AppServiceBase(IDomainService<TEntity> domainService, IUnitOfWork unitOfWork, IAdapter<TEntity, TDto> adaper)
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

        public virtual MyResults SaveOrUpdate(TDto dto)
        {
            // convert to domain
            var domain = _adaper.ToDomain(dto);

            _unitOfWork.BeginTransaction();

            // save and updates
            var results = _domainService.SaveOrUpdate(domain);

            if (results.Type == MyResultsType.Ok)
                _unitOfWork.Commit();

            return results;
        }
    }
}
