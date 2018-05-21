/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.ViewModels;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class LabelAppService : AppServiceBase<Label, LabelDto>, ILabelAppService
    {
        private readonly IExpenseAppService _expenseAppService;

        public LabelAppService(ILabelService service, IExpenseAppService expenseAppService, ILabelAdapter adapter, IUnitOfWork unitOfWork)
            : base(service, adapter, unitOfWork)
        {
            _expenseAppService = expenseAppService;
        }

        public IEnumerable<LabelViewModel> GetAll(DateTime starDateTime, DateTime endDateTime)
        {
            IEnumerable<ExpenseDto> allExpenses = _expenseAppService.GetAll().Where(x => x.Data >= starDateTime && x.Data <= endDateTime);

            return GetAll().GroupJoin(
                    allExpenses,
                    label => label.Id,
                    expense => expense.LabelId,
                    (label, expenses) => new { label, expenses })
                .Select(x => new LabelViewModel
                                 {
                                     Label = x.label,
                                     QuantityOfExpenses = x.expenses.Count(),
                                     Value = x.expenses.Sum(y => y.Value)
                                 });
        }
    }
}
