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
            DateTime startLastMonth = Util.MyDate.GetStartLastMonth(starDateTime.Month, starDateTime.Year);
            DateTime endLastMonth = Util.MyDate.GetEndLastMonth(endDateTime.Month, endDateTime.Year);

            return GetAll()
                .GroupJoin(
                    _expenseAppService.GetAll(),
                    label => label.Id,
                    expense => expense.LabelId,
                    (label, expenses) => new { label, expenses })
                .Select(x => new LabelViewModel
                {
                    Label = x.label,
                    QuantityOfExpenses = x.expenses.Count(y => y.Data >= starDateTime && y.Data <= endDateTime),
                    Value = x.expenses.Where(y => y.Data >= starDateTime && y.Data <= endDateTime).Sum(y => y.Value),

                    LastMonth = x.expenses.Any(y => y.Data >= startLastMonth && y.Data <= endLastMonth) ?
                        x.expenses.Where(y => y.Data >= startLastMonth && y.Data <= endLastMonth).Average(y => y.Value) : 0,
                    Average = x.expenses.Any() ? x.expenses.Average(y => y.Value) : 0
                });
        }
    }
}
