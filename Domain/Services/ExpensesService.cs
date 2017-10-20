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

    public class ExpensesService : DomainServiceBase<Expense>, IExpensesService
    {
        public ExpensesService(IExpensesRepo repository) : base(repository)
        {
            
        }
    }
}
