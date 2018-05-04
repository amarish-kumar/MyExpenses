/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.Services
{
    using MyExpenses.Domain.Models;

    public interface IExpenseService : IService<Expense>
    {
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
