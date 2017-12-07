/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WinForm.Modules
{
    using MyExpenses.Util.IoC;

    public static class InitPresentationModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyPresentationModule());
        }
    }
}
