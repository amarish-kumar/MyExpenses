/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WinForm.Mvp.Interfaces
{
    public interface IPresenter
    {
        /// <summary>
        /// Get view
        /// </summary>
        /// <returns>View</returns>
        IView GetView();
    }
}
