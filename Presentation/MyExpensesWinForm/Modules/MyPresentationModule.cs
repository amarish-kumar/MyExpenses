/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Modules
{
    using MyExpenses.WinForm.Interfaces;
    using MyExpenses.WinForm.Presenter;
    using MyExpenses.WinForm.View;

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
