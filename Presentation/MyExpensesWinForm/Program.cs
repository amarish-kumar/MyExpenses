/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WinForm
{
    using System;
    using System.Configuration;
    using System.Windows.Forms;

    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Modules;
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

            try
            {
                // Loads only necessary modules
                MyKernelService.Init();
                InitPresentationModules.Init();
                InitApplicationModules.Init();
                InitInfrastructureModules.Init();
                InitCrossCuttingModules.Init();

                ExpensePresenter expensePresenter = MyKernelService.GetInstance<ExpensePresenter>();
                Application.Run((Form)expensePresenter.GetView());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
