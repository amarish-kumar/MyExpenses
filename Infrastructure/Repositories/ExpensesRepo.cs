/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Util.Logger;

    public class ExpensesRepo : Repository<Expense>, IExpensesRepo
    {
        public ExpensesRepo(IMyContext context, ILogService log = null) : base(context, log)
        {
        }
    }
}
