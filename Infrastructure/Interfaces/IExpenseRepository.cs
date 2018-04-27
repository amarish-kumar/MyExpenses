/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Interfaces
{
    using MyExpenses.Domain.Models;

    public interface IExpensesRepository : IRepository<Expense>
    {
    }
}
