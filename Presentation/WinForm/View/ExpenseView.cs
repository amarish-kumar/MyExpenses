/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm.View
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using WinForm.Interfaces;
    using WinForm.Model;

    public partial class ExpenseView : Form, IExpenseView
    {
        public ExpenseView()
        {
            InitializeComponent();
        }

        public List<ExpenseModel> Expenses { get; set; }

        public ExpenseModel SelectedExpense { get; set; }

        public void UpdateView()
        {
            UpdateGrid();
            UpdateSelected();
            UpdateFooter();
        }

        /*       
         *  PRIVATE METHODS
        */

        private void UpdateGrid()
        {
            dgvExpenses.DataSource = Expenses;
        }

        private void UpdateSelected()
        {
            if (SelectedExpense == null)
                return;

            txtId.Text = SelectedExpense.Id.ToString();
            txtName.Text = SelectedExpense.Name;
            txtValue.Text = SelectedExpense.Value.ToString("D");
            txtDate.Text = SelectedExpense.Date.ToShortDateString();
        }

        private void UpdateFooter()
        {
            // Method intentionally left empty.
        }
    }
}
