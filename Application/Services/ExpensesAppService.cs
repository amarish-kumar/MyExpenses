/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    public class ExpensesAppService : AppServiceBase<Expense, ExpenseDto>, IExpensesAppService<ExpenseDto>
    {
        private readonly IExpensesService _domainService;
        private readonly ITagsService _tagsDomainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdapter<Expense, ExpenseDto> _adaper;

        public ExpensesAppService(
            IExpensesService domainService,
            //ITagsService tagsDomainService,
            IUnitOfWork unitOfWork,
            IAdapter<Expense, ExpenseDto> adaper) :
            base(domainService, unitOfWork, adaper)
        {
            _domainService = domainService;
            //_tagsDomainService = tagsDomainService;
            _unitOfWork = unitOfWork;
            _adaper = adaper;
        }

        public override ICollection<ExpenseDto> GetAll()
        {
            // Get expenses from domain
            var domains = _domainService.GetAll(x => x.Tags).ToList();

            // Convert expenses to DTO
            var dtos = domains.Select(_adaper.ToDto).ToList();

            return dtos;
        }

        public override MyResults SaveOrUpdate(ExpenseDto dto)
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
