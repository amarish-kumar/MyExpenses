/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    public class TagsService : DomainService<Tag>, ITagsService
    {
        private readonly IExpensesRepository _expensesRepository;

        public TagsService(ITagsRepository repository, IExpensesRepository expensesRepository)
            : base(repository)
        {
            _expensesRepository = expensesRepository;
        }

        public override MyResults Remove(Tag domain)
        {
            // get all expenses with this tag
            foreach (Expense expense in _expensesRepository.Get(x => x.Tag != null))
            {
                // remove tag ref
                expense.Tag = null;

                // update expense
                _expensesRepository.AddOrUpdate(expense);
            }

            return base.Remove(domain);
        }
    }
}
