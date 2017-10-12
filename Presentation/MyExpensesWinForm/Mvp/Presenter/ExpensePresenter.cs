/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WinForm.Mvp.Presenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.CrossCutting.Results;
    using MyExpenses.WinForm.Mvp.Interfaces;
    using MyExpenses.WinForm.Mvp.Model;

    public class ExpensePresenter : PresenterBase
    {
        private readonly IExpenseView _view;
        private readonly IExpensesAppService _appService;

        public ExpensePresenter(IExpenseView view, IExpensesAppService appService) : base(view)
        {
            _view = view;
            _appService = appService;

            Binding();
            InitEvents();
        }

        /*       
         *  PRIVATE METHODS
        */

        private void Binding()
        {
            List<ExpenseDto> expensesDto = _appService.GetAllExpenses();

            List<ExpenseModel> expenses = expensesDto.Select(x => new ExpenseModel(x)).ToList();

            _view.Expenses = expenses;

            _view.UpdateView();
        }

        private void InitEvents()
        {
            _view.AddEvent += UpdateAndAddExpense;
            _view.UpdateEvent += UpdateAndAddExpense;
            _view.DeleteEvent += DeleteExpense;
        }

        private void UpdateAndAddExpense(object sender, EventArgs e)
        {
            ExpenseModel expenseModel = _view.SelectedExpense;

            MyResults results = _appService.SaveOrUpdateExpense(expenseModel.ConvertToDto());

            if (results.Type == MyResultsType.Ok)
            {
                Binding();
            }

            ShowResults(results);
        }

        private void DeleteExpense(object sender, EventArgs e)
        {
            ExpenseModel expenseModel = _view.SelectedExpense;

            MyResults results = _appService.RemoveExpense(expenseModel.ConvertToDto());

            if (results.Type == MyResultsType.Ok)
            {
                Binding();
            }

            ShowResults(results);
        }
    }
}
