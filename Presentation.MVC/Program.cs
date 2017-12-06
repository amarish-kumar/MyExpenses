/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/


namespace Presentation.MVC
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Util.IoC;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Loads only necessary modules
            MyKernelService.Init();
            MyApplicationModule.Init();
            MyInfrastructureModule.Init();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
