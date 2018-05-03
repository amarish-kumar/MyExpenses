/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System.Collections.Generic;

    using MyExpenses.Application.Dtos;

    public interface IExpenseAppService : IAppService<ExpenseDto>
    {
        IEnumerable<ExpenseDto> GetAllIncoming();

        IEnumerable<ExpenseDto> GetAllOutcoming();
    }
}
