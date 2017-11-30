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

    public class ExpensesService : DomainService<Expense>, IExpensesService
    {
        private readonly ITagsRepository _tagsRepo;

        public ExpensesService(IExpensesRepository repository, ITagsRepository tagsRepo)
            : base(repository)
        {
            _tagsRepo = tagsRepo;
        }

        public override MyResults AddOrUpdate(Expense domain)
        {
            // Update dependencies references
            if(domain.Tag != null)
                domain.Tag = _tagsRepo.GetById(domain.Tag.Id);

            return base.AddOrUpdate(domain);
        }
    }
}
