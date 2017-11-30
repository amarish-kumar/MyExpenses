/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Domain.Models;

    public interface IExpensesAppService : IAppService<Expense, ExpenseDto>
    {
    }
}
