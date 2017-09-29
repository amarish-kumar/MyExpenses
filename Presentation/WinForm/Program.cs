namespace WinFormPresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using Domain.Model;

    using Infrastructure.Modules;
    using Infrastructure.Repositories;
    using Infrastructure.Services;

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

            // Test
            ExpenseRepo expenseRepo = MyKernelService.GetInstance<ExpenseRepo>();
            List<Expense> expenses = expenseRepo.GetAll().ToList();

            foreach (Expense expense in expenses)
            {
                Console.WriteLine(expense.Name);
            }

            Application.Run(new Form1());
        }
    }
}
