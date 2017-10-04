/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Mvp.Presenter
{
    using System;
    using System.Windows.Forms;

    using MyExpenses.CrossCutting.Results;
    using MyExpenses.WinForm.Mvp.Interfaces;
    using MyExpenses.WinForm.Properties;

    public class PresenterBase : IPresenter
    {
        private readonly IView _view;

        public PresenterBase(IView view)
        {
            _view = view;
        }

        public IView GetView()
        {
            return _view;
        }

        public void ShowResults(MyResults results)
        {
            if (results.Type == MyResultsType.Ok)
            {
                MessageBox.Show(
                    (Form)_view,
                    String.Format(Resources.ActionAndSuccess, results.Action),
                    Resources.ResultsTitle, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    (Form)_view, 
                    String.Format(Resources.ActionAndMessage, results.Action, results.Message),
                    Resources.ResultsTitle, 
                    MessageBoxButtons.OK,
                    results.Type == MyResultsType.Error ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
            }
        }
    }
}
