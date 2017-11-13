/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Models;

    using Ninject.Modules;

    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExpensesAppService<ExpenseDto>>().To<ExpensesAppService>().InSingletonScope();
            Bind<ITagsAppService<TagDto>>().To<TagsAppService>().InSingletonScope();

            Bind<IAdapter<Expense, ExpenseDto>>().To<ExpensesAdapter>().InSingletonScope();
            Bind<IAdapter<Tag, TagDto>>().To<TagsAdapter>().InSingletonScope();
        }
    }
}
