/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Application.Dtos;

    public interface IExpenseAppService : IAppService<ExpenseDto>
    {
        /// <summary>
        /// Get all incoming expenses
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">End time</param>
        /// <returns>Set of expenses</returns>
        IEnumerable<ExpenseDto> GetAllIncoming(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Get all outcoming expenses
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">End time</param>
        /// <returns>Set of expenses</returns>
        IEnumerable<ExpenseDto> GetAllOutcoming(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Get all dates
        /// </summary>
        /// <returns>All dates</returns>
        IEnumerable<DateTime> GetAllMonthsAndYears();

        /// <summary>
        /// Count expenses by label
        /// </summary>
        /// <param name="labelId">Label id</param>
        /// <returns>Number of expenses</returns>
        int CountByLabel(long labelId);

        /// <summary>
        /// Sum all values by label
        /// </summary>
        /// <param name="labelId">Label id</param>
        /// <returns>Sum values</returns>
        float SumValuesByLabel(long labelId);
    }
}
