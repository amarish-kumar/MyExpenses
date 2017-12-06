/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.Console
{
    using System;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Util.IoC;

    public class Program
    {
        static void Main(string[] args)
        {
            // Loads only necessary modules
            MyKernelService.Init();
            MyApplicationModule.Init();
            MyInfrastructureModule.Init();

            Console.WriteLine("Expenses:");

            var appService = MyKernelService.GetInstance<IExpensesAppService>();
            foreach (ExpenseDto expenseDto in appService.GetAll())
            {
                Console.WriteLine($"{expenseDto.Name}");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
