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

    public class TagsRepo : Repository<Tag>, ITagsRepo
    {
        public TagsRepo(
            IMyContext context, 
            ILogService log = null) : base(context, log)
        {
        }

        public override MyResults Remove(Tag domain)
        {
            IExpensesRepo expensesRepo = MyKernelService.GetInstance<IExpensesRepo>();

            // TODO move this logic to Domain

            // get all expenses with this tag
            var expenses = expensesRepo.Get(x => x.Tags.Any(y => y.Id == domain.Id)).ToList();
            expenses.ForEach(
                x =>
                    {
                        // remove tag ref
                        x.Tags.Remove(x.Tags.FirstOrDefault(y => y.Id == domain.Id));
                        // update expense
                        expensesRepo.AddOrUpdate(x);
                    });

            return base.Remove(domain);
        }
    }
}
