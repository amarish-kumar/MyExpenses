/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication
{
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using MyExpenses.Application.Modules;
    using MyExpenses.Application.Services;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Util.IoC;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //try
            //{
            //    // Loads only necessary modules
            //    MyKernelService.Init();
            //    InitApplicationModules.Init();
            //    InitInfrastructureModules.Init();

            //    var expensesAppService = MyKernelService.GetInstance<ExpensesAppService>();
            //    var allExpenses = expensesAppService.GetAllExpenses();
            //    allExpenses.ForEach(Console.WriteLine);
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
        }
    }
}
