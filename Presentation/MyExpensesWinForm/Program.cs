/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm
{
    using System;
    using System.Windows.Forms;

    using MyExpenses.Application.Modules;
    using MyExpenses.CrossCutting.IoC;
    using MyExpenses.WinForm.Modules;
    using MyExpenses.WinForm.Mvp.Presenter;

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
            InitPresentationModules.Init();
            InitApplicationModules.Init();
            InitApplicationModules.InitInfrastructureModules();

            ExpensePresenter expensePresenter = MyKernelService.GetInstance<ExpensePresenter>();
            Application.Run((Form)expensePresenter.GetView());
        }
    }
}
