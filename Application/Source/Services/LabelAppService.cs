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
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class LabelAppService : AppServiceBase<Label, LabelDto>, ILabelAppService
    {
        private readonly ILabelService _service;
        private readonly ILabelAdapter _adapter;
        private readonly IExpenseAppService _expenseAppService;

        public LabelAppService(ILabelService service, IExpenseAppService expenseAppService, ILabelAdapter adapter, IUnitOfWork unitOfWork)
            : base(service, adapter, unitOfWork)
        {
            _service = service;
            _adapter = adapter;
            _expenseAppService = expenseAppService;
        }

        public IEnumerable<IndexLabelDto> Get(DateTime starDateTime, DateTime endDateTime)
        {
            DateTime startLastMonth = Util.MyDate.GetStartLastMonth(starDateTime.Month, starDateTime.Year);
            DateTime endLastMonth = Util.MyDate.GetEndLastMonth(endDateTime.Month, endDateTime.Year);

            Func<ExpenseDto, bool> filterDate = (ExpenseDto x) => x.Data >= starDateTime && x.Data <= endDateTime;
            Func<ExpenseDto, bool> filterLastMonth = (ExpenseDto x) => x.Data >= startLastMonth && x.Data <= endLastMonth;
            Func<ExpenseDto, bool> filterUntilThisMonth = (ExpenseDto x) => x.Data <= endLastMonth;

            return _service.Get()
                .GroupJoin(
                    _expenseAppService.Get(),
                    label => label.Id,
                    expense => expense.LabelId,
                    (label, expenses) => new { label, expenses })
                .Select(x => new IndexLabelDto
                {
                    Label = _adapter.ModelToDto(x.label),
                    Amount = x.expenses.Count(filterDate),
                    Value = x.expenses.Where(filterDate).Sum(y => y.Value),

                    LastMonth = x.expenses.Where(filterLastMonth).Sum(y => y.Value),
                    Average = x.expenses.Any(filterUntilThisMonth) ? x.expenses.Where(filterUntilThisMonth).Average(y => y.Value) : 0
                });
        }
    }
}
