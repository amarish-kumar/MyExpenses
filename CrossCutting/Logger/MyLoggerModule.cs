/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.CrossCutting.Logger
{
    using System.Configuration;

    using Ninject.Modules;

    public class MyLogggerModule : NinjectModule
    {
        private readonly string _connectionString;

        public MyLogggerModule()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyLocalDatabase"].ConnectionString;
        }

        public override void Load()
        {
            Bind<IMyLogger>().To<IMyLogger>()
                .InSingletonScope()
                .WithConstructorArgument("connectionString", _connectionString);
        }
    }
}
