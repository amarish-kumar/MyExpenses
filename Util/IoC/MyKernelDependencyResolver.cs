/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.IoC
{
    using System;
    using System.Collections.Generic;
    //using System.Web.Mvc;

    public class MyKernelDependencyResolver// : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return MyKernelService.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return MyKernelService.GetAll(serviceType);
        }
    }
}
