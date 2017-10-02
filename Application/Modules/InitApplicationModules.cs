/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Application.Modules
{
    using CrossCutting.IoC;

    using Infrastructure.Modules;

    public static class InitApplicationModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyApplicationModule());

            InitInfrastructureModules.Init();
        }
    }
}
