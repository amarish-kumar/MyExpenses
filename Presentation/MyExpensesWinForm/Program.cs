/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm
{
    using System;
    using System.Configuration;
    using System.Windows.Forms;

    using MyExpenses.Application.Modules;
    using MyExpenses.CrossCutting.IoC;
    using MyExpenses.CrossCutting.Modules;
    using MyExpenses.Infrastructure.Modules;
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

            string connectionString = ConfigurationManager.ConnectionStrings["MyLocalDatabaseConnectionString"].ConnectionString;

            try
            {
                // Loads only necessary modules
                MyKernelService.Init();
                InitPresentationModules.Init();
                InitApplicationModules.Init();
                InitInfrastructureModules.Init();
                InitCrossCuttingModules.Init(connectionString);

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
