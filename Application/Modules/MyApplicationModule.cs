/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Application.Modules
{
    using Application.Interfaces;
    using Application.Services;

    using Ninject.Modules;

    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExpensesAppService>().To<ExpensesAppService>().InSingletonScope();
        }
    }
}
