/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.Console
{
    using System;
    using System.Linq;

    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Util.IoC;
    using MyExpenses.Application.Services;

    public class Program
    {
        static void Main(string[] args)
        {
            // Loads only necessary modules
            MyKernelService.Init();
            MyApplicationModule.Init();
            MyInfrastructureModule.Init();

            var app = MyKernelService.GetInstance<ExpensesAppService>();
            var all = app.GetAll(x => x.Tag).ToList();

            foreach (var e in all)
            {
                Console.WriteLine(e.Name);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
