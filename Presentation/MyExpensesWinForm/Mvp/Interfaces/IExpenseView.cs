/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Mvp.Interfaces
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.WinForm.Mvp.Model;
    using MyExpenses.WinForm.Mvp.View;

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

        event EventHandler AddEvent;
        event EventHandler UpdateEvent;
        event EventHandler DeleteEvent;
    }
}
