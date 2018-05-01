/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.Repositories
{
    using MyExpenses.Domain.Models;

    public interface IExpenseRepository : IService<Expense>
    {
    }
}
