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

    public class ExpenseAppService : AppServiceBase<Expense, ExpenseDto>, IExpenseAppService
    {
        private readonly IExpenseService _service;
        private readonly IExpenseAdapter _adapter;

        public ExpenseAppService(IExpenseService service, IExpenseAdapter adapter, IUnitOfWork unitOfWork)
            : base(service, adapter, unitOfWork)
        {
            _service = service;
            _adapter = adapter;
        }

        public IndexExpenseDto GetIndexExpenses(DateTime startTime, DateTime endTime)
        {
            return new IndexExpenseDto
            {
                Incoming = _service.GetAllIncoming(startTime, endTime).Select(x => _adapter.ModelToDto(x)).ToList(),
                Outcoming = _service.GetAllOutcoming(startTime, endTime).Select(x => _adapter.ModelToDto(x)).ToList(),
                Month = startTime.Month,
                Year = startTime.Year
            };
        }

        public override IEnumerable<ExpenseDto> Get()
        {
            return _service
                .Get(x => x.Label, x => x.Payment)
                .Select(x => _adapter.ModelToDto(x));
        }

        public override ExpenseDto GetById(long id)
        {
            var model = _service.GetById(id, x => x.Label, x => x.Payment);
            return _adapter.ModelToDto(model);
        }

        public IEnumerable<int> GetAllYears()
        {
            return _service
                .Get()
                .Select(x => x.Data.Year)
                .Distinct();
        }
    }
}
