/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.IoC
{
    using Ninject.Modules;

    public static class MyKernelService
    {
        public static void Init() => MyKernel.Init();

        public static void AddModule(INinjectModule module) => MyKernel.AddModule(module);

        public static T GetInstance<T>() => MyKernel.GetInstance<T>();
    }
}
