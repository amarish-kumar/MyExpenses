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
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Logger;
    using MyExpenses.Util.Results;

    public class ExpensesRepo : Repository<Expense>, IExpensesRepo
    {
        public ExpensesRepo(
            IMyContext context,
            ILogService log = null) : base(context, log)
        {
        }

        public override MyResults AddOrUpdate(Expense domain)
        {
            ITagsRepo tagsRepo = MyKernelService.GetInstance<ITagsRepo>();

            // TODO move this logic to Domain
            domain.Tags = domain.Tags.Select(x => tagsRepo.GetById(x.Id)).ToList();

            return base.AddOrUpdate(domain);
        }
    }
}
