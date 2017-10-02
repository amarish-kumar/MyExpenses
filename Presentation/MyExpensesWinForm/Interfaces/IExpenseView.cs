/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Interfaces
{
    using System.Collections.Generic;

    using MyExpenses.WinForm.Model;
    using MyExpenses.WinForm.View;

    public interface IExpenseView : IView
    {
        /// <summary>
        /// Gets and sets all expenses
        /// </summary>
        ICollection<ExpenseModel> Expenses { get; set; }

        /// <summary>
        /// Gets and sets selected expense
        /// </summary>
        ExpenseModel SelectedExpense { get; set; }

        /// <summary>
        /// Update view
        /// </summary>
        void UpdateView();
    }
}
