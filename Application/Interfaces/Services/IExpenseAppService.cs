/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;

    public interface IExpenseAppService : IService<Expense>
    {
    }
}
