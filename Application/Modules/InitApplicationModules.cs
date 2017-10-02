/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Application.Modules
{
    using Infrastructure.Modules;

    using MyExpenses.CrossCutting.IoC;

    public static class InitApplicationModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyApplicationModule());

            InitInfrastructureModules.Init();
        }
    }
}
