/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.IoC
{
    using System.Linq;

    using Ninject;
    using Ninject.Modules;

    public static class MyKernel
    {
        private static IKernel _kernel;

        public static void Init()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
            }
        }

        public static void AddModule(INinjectModule module)
        {
            var exists = _kernel.GetModules().FirstOrDefault(x => x.Name == module.Name);
            if (exists == null)
            {
                _kernel.Load(module);
            }
        }

        public static T GetInstance<T>()
        {
            if (_kernel == null)
            {
                Init();
            }

            return _kernel.Get<T>();
        }
    }
}
