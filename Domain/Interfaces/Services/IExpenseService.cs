/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Domain.Models;

    public interface IExpenseService : IService<Expense>
    {
        IEnumerable<Expense> GetAllIncoming(DateTime startTime, DateTime endTime);

        IEnumerable<Expense> GetAllOutcoming(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Remove label from all expenses
        /// </summary>
        /// <param name="labelId">Label id</param>
        void RemoveLabelFromExpenses(long labelId);

        /// <summary>
        /// Remove payment method from all expenses
        /// </summary>
        /// <param name="paymentId">Payment id</param>
        void RemovePaymentFromExpenses(long paymentId);
    }
}
