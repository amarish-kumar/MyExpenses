/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.IoC
{
    using System;
    using System.Collections.Generic;

    using Ninject.Modules;

    public static class MyKernelService
    {
        public static void Init() => MyKernel.Init();

        public static void Reset() => MyKernel.Reset();

        public static void AddModule(INinjectModule module) => MyKernel.AddModule(module);

        public static T GetInstance<T>() => MyKernel.GetInstance<T>();

        public static IEnumerable<object> GetAll(Type type) => MyKernel.GetAll(type);

        public static object Get(Type type) => MyKernel.Get(type);
    }
}
