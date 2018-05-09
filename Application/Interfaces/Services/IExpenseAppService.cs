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
        /// <summary>
        /// Get all incoming expenses
        /// </summary>
        /// <returns>Set of incoming expenses</returns>
        IEnumerable<ExpenseDto> GetAllIncoming();

        /// <summary>
        /// Get all outcoming expenses
        /// </summary>
        /// <returns>Set of outcoming expenses</returns>
        IEnumerable<ExpenseDto> GetAllOutcoming();
    }
}
