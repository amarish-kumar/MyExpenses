/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Modules
{
    using MyExpenses.CrossCutting.IoC;

    public static class InitPresentationModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyPresentationModule());
        }
    }
}
