/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.CrossCutting.Modules
{
    using MyExpenses.CrossCutting.IoC;
    using MyExpenses.CrossCutting.Logger;

    public static class InitCrossCuttingModules
    {
        public static void Init(string connectionString)
        {
            MyKernelService.AddModule(new MyLogggerModule(connectionString));
        }
    }
}
