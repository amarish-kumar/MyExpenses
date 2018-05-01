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

    public class ExpensesRepository : RepositoryBase<Expense>, IExpensesRepository
    {
        public ExpensesRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
