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

        public IEnumerable<IndexLabelDto> Get(DateTime startDateTime, DateTime endDateTime)
        {
            DateTime startLastMonth = Util.MyDate.GetStartLastMonth(startDateTime.Month, startDateTime.Year);
            DateTime endLastMonth = Util.MyDate.GetEndLastMonth(endDateTime.Month, endDateTime.Year);

            bool FilterDate(Expense x) => x.Data >= startDateTime && x.Data <= endDateTime;
            bool FilterDateIncoming(Expense x) => x.Data >= startDateTime && x.Data <= endDateTime && x.IsIncoming;
            bool FilterDateOutcoming(Expense x) => x.Data >= startDateTime && x.Data <= endDateTime && !x.IsIncoming;
            bool FilterLastMonthIncoming(Expense x) => x.Data >= startLastMonth && x.Data <= endLastMonth && x.IsIncoming;
            bool FilterLastMonthOutComing(Expense x) => x.Data >= startLastMonth && x.Data <= endLastMonth && !x.IsIncoming;
            bool FilterUntilThisMonth(Expense x) => x.Data <= endLastMonth;

            return _service.Get(x => x.Expenses)
                .Select(x => new IndexLabelDto
                {
                    Label = _adapter.ModelToDto(x),
                    Amount = x.Expenses.Count(FilterDate),
                    Value = x.Expenses.Where(FilterDateIncoming).Select(y => y.Value).Sum() -
                            x.Expenses.Where(FilterDateOutcoming).Select(y => y.Value).Sum(),

                    LastMonth = x.Expenses.Where(FilterLastMonthIncoming).Select(y => y.Value).Sum() -
                                x.Expenses.Where(FilterLastMonthOutComing).Select(y => y.Value).Sum(),

                    Average = x.Expenses.Any(FilterUntilThisMonth) ? x.Expenses.Where(FilterUntilThisMonth).Select(y => y.Value).Average() : 0
                })
                .OrderBy(x => x.Label.Name);
        }
    }
}
