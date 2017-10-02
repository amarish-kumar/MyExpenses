/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Application.Interfaces
{
    using System.Collections.Generic;

    using MyExpenses.Application.DataTransferObject;

    public interface IExpensesAppService
    {
        /// <summary>
        /// Get all expenses available
        /// </summary>
        /// <returns>All expenses</returns>
        List<ExpensesDto> GetAllExpenses();
    }
}
