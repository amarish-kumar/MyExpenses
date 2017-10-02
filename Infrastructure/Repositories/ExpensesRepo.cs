/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Interfaces;

    public class ExpensesRepo : RepositoryBase<Expense>, IExpensesRepo
    {
        public ExpensesRepo(MyContext context) : base(context)
        {
        }
    }
}
