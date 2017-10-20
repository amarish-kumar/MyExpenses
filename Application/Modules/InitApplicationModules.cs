/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using MyExpenses.Util.IoC;

    public static class InitApplicationModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyApplicationModule());
        }
    }
}
