/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Modules
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Services;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Logger;

    using Ninject.Modules;

    public class MyInfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            // Repositories
            Bind<IExpensesRepo>().To<ExpensesRepo>().InSingletonScope();
            Bind<ITagsRepo>().To<TagsRepo>().InSingletonScope();

            // Domain Services
            Bind<IExpensesService>().To<ExpensesService>().InSingletonScope();
            Bind<ITagsService>().To<TagsService>().InSingletonScope();

            // Context
            Bind<IMyContext>().To<MyContext>().InSingletonScope();

            // Unit of work
            Bind<IUnitOfWork>().To<UnitOfWork>();

            // Log service
            Bind<ILogService>().To<LogService>().InSingletonScope();
        }

        public static void Init() => MyKernelService.AddModule(new MyInfrastructureModule());
    }
}
