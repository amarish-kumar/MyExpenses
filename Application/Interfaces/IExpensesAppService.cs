/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    using System.Collections.Generic;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Util.Results;

    public interface IExpensesAppService
    {
        /// <summary>
        /// Get all expenses available
        /// </summary>
        /// <returns>All expenses</returns>
        List<ExpenseDto> GetAllExpenses();

        /// <summary>
        /// Save or update a expense
        /// </summary>
        /// <param name="expenseDto">Expense to be save or updated</param>
        /// <returns>Result of the operation</returns>
        MyResults SaveOrUpdateExpense(ExpenseDto expenseDto);

        /// <summary>
        /// Remove expense
        /// </summary>
        /// <param name="expenseDto">Expense to be removed</param>
        /// <returns>Result of the operation</returns>
        MyResults RemoveExpense(ExpenseDto expenseDto);
    }
}
