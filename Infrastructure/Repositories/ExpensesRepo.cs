/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System.Linq;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Util.Logger;
    using MyExpenses.Util.Results;

    public class ExpensesRepo : Repository<Expense>, IExpensesRepo
    {
        private readonly ITagsRepo _tagRepo;

        public ExpensesRepo(
            IMyContext context,
            ITagsRepo tagRepo,
            ILogService log = null) : base(context, log)
        {
            _tagRepo = tagRepo;
        }

        public override MyResults AddOrUpdate(Expense domain)
        {
            MyResults result = UpdateDependecies(domain);

            if (result.Type == MyResultsType.Error)
                return result;

            return base.AddOrUpdate(domain);
        }

        private MyResults UpdateDependecies(Expense domain)
        {
            domain.Tags = domain.Tags.Select(x => _tagRepo.GetById(x.Id)).ToList();

            return new MyResults(MyResultsType.Ok);
        }
    }
}
