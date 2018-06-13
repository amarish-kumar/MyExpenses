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
        IndexExpenseDto GetIndexExpenses(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Get all years
        /// </summary>
        /// <returns>All years</returns>
        IEnumerable<int> GetAllYears();
    }
}
