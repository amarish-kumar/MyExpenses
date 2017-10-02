/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm.Modules
{
    using Ninject.Modules;

    using WinForm.Interfaces;
    using WinForm.Presenter;
    using WinForm.View;

    public class MyPresentationModule : NinjectModule
    {
        public override void Load()
        {
            // View
            Bind<IExpenseView>().To<ExpenseView>().InSingletonScope();

            // Presenter
            Bind<IPresenter>().To<ExpensePresenter>().InSingletonScope();
        }
    }
}
