namespace Infrastructure.Modules
{
    using System.Configuration;

    using Domain.Interfaces.Repositories;

    using Infrastructure.Context;
    using Infrastructure.Repositories;

    using Ninject.Modules;

    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            // TODO add services, applications and repositories
            Bind<IExpenseRepo>().To<ExpenseRepo>().InSingletonScope();

            // Context
            Bind<MyContext>().ToSelf().InSingletonScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["MyLocalDataBase"].ConnectionString);
        }
    }
}
