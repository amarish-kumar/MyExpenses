/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm
{
    using System;
    using System.Windows.Forms;

    using Application.Modules;

    using CrossCutting.IoC;

    using WinForm.Modules;
    using WinForm.Presenter;
    
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

            ExpensePresenter expensePresenter = MyKernelService.GetInstance<ExpensePresenter>();
            Application.Run((Form)expensePresenter.GetView());
        }
    }
}
