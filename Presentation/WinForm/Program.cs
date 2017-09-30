/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinFormPresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using Domain.Model;

    using Infrastructure.Context;
    using Infrastructure.Modules;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using Infrastructure.UnitOfWork;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Loads only necessary modules
            MyKernelService.Init();
            MyKernelService.AddModule(new MyModule());

            var unitOfWork = MyKernelService.GetInstance<UnitOfWork>();

            unitOfWork.BeginTransaction();

            MyContext context = MyKernelService.GetInstance<MyContext>();
            context.Expenses.Add(new Expense
            {
                Name = "name",
                Value = 2.0f,
                Date = DateTime.Today
            });
            unitOfWork.Commit();

            // Test
            ExpenseRepo expenseRepo = MyKernelService.GetInstance<ExpenseRepo>();
            List<Expense> expenses = expenseRepo.GetAll().ToList();

            foreach (Expense expense in expenses)
            {
                Console.WriteLine(expense.Name);
            }

            Application.Run(new Main());
        }
    }
}
