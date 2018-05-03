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

    public class ExpenseService : ServiceBase<Expense>, IExpenseService
    {
        public ExpenseService(IExpenseRepository repository)
            : base(repository)
        {
        }
    }
}
