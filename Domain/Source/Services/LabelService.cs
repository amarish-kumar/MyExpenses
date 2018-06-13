/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class LabelService : ServiceBase<Label>, ILabelService
    {
        private readonly ILabelRepository _repository;
        private readonly IExpenseService _expenseService;

        public LabelService(ILabelRepository repository, IExpenseService expenseService)
            : base(repository)
        {
            _repository = repository;
            _expenseService = expenseService;
        }

        public override bool Remove(long id)
        {
            _expenseService.RemoveLabelFromExpenses(id);

            return base.Remove(id);
        }
    }
}
