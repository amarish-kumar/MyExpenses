/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Modules
{
    using CrossCutting.IoC;

    public static class InitInfrastructureModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyInfrastructureModule());
        }
    }
}
