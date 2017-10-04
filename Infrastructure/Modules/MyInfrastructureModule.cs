/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Infrastructure.Modules
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;

    using Ninject.Modules;

    public class MyInfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            // Repositories
            Bind<IExpensesRepo>().To<ExpensesRepo>().InSingletonScope();

            // Context
            Bind<MyContext>().ToSelf().InSingletonScope();

            // Unit of work
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
