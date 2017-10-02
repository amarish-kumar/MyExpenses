/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm.Presenter
{
    using WinForm.View;

    public interface IPresenter
    {
        IView GetView();
    }
}
