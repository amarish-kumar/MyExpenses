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
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    public class ExpensesAppService : AppServiceBase<Expense, ExpenseDto>, IExpensesAppService
    {
        private readonly IExpensesService _domainService;
        private readonly IExpensesAdapter _adaper;

        public ExpensesAppService(
            IExpensesService domainService,
            IUnitOfWork unitOfWork,
            IExpensesAdapter adaper) :
            base(domainService, unitOfWork, adaper)
        {
            _domainService = domainService;
            _adaper = adaper;
        }
    }
}
