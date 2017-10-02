/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Infrastructure.Modules
{
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Interfaces;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;

    using Ninject.Modules;

    public class MyInfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            // TODO add services, applications and repositories
            Bind<IExpensesRepo>().To<ExpensesRepo>().InSingletonScope();

            // Context
            Bind<MyContext>().ToSelf().InSingletonScope();

            // Unit of work
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
