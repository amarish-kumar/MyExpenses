/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Modules
{
    using System.Configuration;

    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.UnitOfWork;

    using Infrastructure.Context;
    using Infrastructure.Repositories;
    using Infrastructure.UnitOfWork;

    using Ninject.Modules;

    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            // TODO add services, applications and repositories
            Bind<IExpenseRepo>().To<ExpenseRepo>().InSingletonScope();

            // Context
            Bind<MyContext>().ToSelf().InSingletonScope();

            // Unit of work
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
