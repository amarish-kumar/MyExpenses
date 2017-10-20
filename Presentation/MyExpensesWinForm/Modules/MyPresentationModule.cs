/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WinForm.Modules
{
    using MyExpenses.WinForm.Mvp.Interfaces;
    using MyExpenses.WinForm.Mvp.Presenter;
    using MyExpenses.WinForm.Mvp.View;

    using Ninject.Modules;

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
