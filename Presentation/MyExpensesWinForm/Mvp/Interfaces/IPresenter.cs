/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Mvp.Interfaces
{
    using MyExpenses.WinForm.Mvp.View;

    public interface IPresenter
    {
        /// <summary>
        /// Get view
        /// </summary>
        /// <returns>View</returns>
        IView GetView();
    }
}
