/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Presenter
{
    using MyExpenses.WinForm.View;

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
    }
}
