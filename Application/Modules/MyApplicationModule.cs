/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Services;
    using MyExpenses.Util.IoC;
    using Ninject.Modules;

    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExpensesAppService>().To<ExpensesAppService>().InSingletonScope();
            Bind<ITagsAppService>().To<TagsAppService>().InSingletonScope();

            Bind<IExpensesAdapter>().To<ExpensesAdapter>().InSingletonScope();
            Bind<ITagsAdapter>().To<TagsAdapter>().InSingletonScope();
        }

        public static void Init() => MyKernelService.AddModule(new MyApplicationModule());
    }
}
