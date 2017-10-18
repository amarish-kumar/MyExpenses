/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.CrossCutting.Modules
{
    using MyExpenses.CrossCutting.IoC;
    using MyExpenses.CrossCutting.Logger;

    public static class InitCrossCuttingModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyLogggerModule());
        }
    }
}
