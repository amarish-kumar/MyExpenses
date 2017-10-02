/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Presenter
{
    using MyExpenses.WinForm.View;

    public interface IPresenter
    {
        /// <summary>
        /// Get view
        /// </summary>
        /// <returns>View</returns>
        IView GetView();
    }
}
