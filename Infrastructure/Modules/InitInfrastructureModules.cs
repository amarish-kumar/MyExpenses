/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Modules
{
    using MyExpenses.Util.IoC;

    public static class InitInfrastructureModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyInfrastructureModule());
        }
    }
}
