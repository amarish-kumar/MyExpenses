/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm.Presenter
{
    using System.Collections.Generic;
    using System.Linq;

    using Application.DataTransferObject;
    using Application.Interfaces;

    using WinForm.Interfaces;
    using WinForm.Model;

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

        private void Binding()
        {
            List<ExpensesDto> expensesDto = _appService.GetAllExpenses();

            List<ExpenseModel> expenses = expensesDto.Select(
                x => new ExpenseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Value = x.Value,
                    Date = x.Date
                }).ToList();

            _view.Expenses = expenses;

            _view.UpdateView();
        }

        private void InitEvents()
        {
        }
    }
}
