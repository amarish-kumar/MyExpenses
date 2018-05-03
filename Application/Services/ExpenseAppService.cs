/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;

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

        public IEnumerable<ExpenseDto> GetAllIncoming()
        {
            var all = _service.Get(x => x.IsIncoming, x => x.Label, x => x.Payment);
            return all.Select(x => _adapter.ModelToDto(x));
        }

        public IEnumerable<ExpenseDto> GetAllOutcoming()
        {
            var all = _service.Get(x => !x.IsIncoming, x => x.Label, x => x.Payment);
            return all.Select(x => _adapter.ModelToDto(x));
        }

        public override ExpenseDto GetById(long id)
        {
            var model = _service.GetById(id, x => x.Label, x => x.Payment);
            return _adapter.ModelToDto(model);
        }
    }
}
