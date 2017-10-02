/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Infrastructure.Interfaces
{
    using MyExpenses.Domain.Models;

    public interface IExpensesRepo : IRepositoryBase<Expense>
    {
    }
}
