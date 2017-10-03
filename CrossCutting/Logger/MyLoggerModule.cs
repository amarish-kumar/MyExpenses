/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.CrossCutting.Logger
{
    using Ninject.Modules;

    public class MyLogggerModule : NinjectModule
    {
        private readonly string _connectionString;

        public MyLogggerModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IMyLogger>().To<IMyLogger>()
                .InSingletonScope()
                .WithConstructorArgument("connectionString", _connectionString);
        }
    }
}
