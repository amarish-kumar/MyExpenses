/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm.Interfaces
{
    using System.Collections.Generic;

    using WinForm.Model;
    using WinForm.View;

    public interface IExpenseView : IView
    {
        List<ExpenseModel> Expenses { get; set; }

        ExpenseModel SelectedExpense { get; set; }

        void UpdateView();
    }
}
