/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.View
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using MyExpenses.WinForm.Interfaces;
    using MyExpenses.WinForm.Model;

    public partial class ExpenseView : Form, IExpenseView
    {
        public ExpenseView()
        {
            InitializeComponent();
            InitEvents();
        }

        public ICollection<ExpenseModel> Expenses { get; set; }

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

        private void InitEvents()
        {
            dgvExpenses.SelectionChanged += DgvExpensesSelectionChanged;
        }

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
            txtValue.Text = $"{SelectedExpense.Value:0.00}";
            txtDate.Text = SelectedExpense.Date.ToShortDateString();
        }

        private void UpdateFooter()
        {
            // Method intentionally left empty.
        }

        private void DgvExpensesSelectionChanged(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count <= 0)
                return;

            SelectedExpense = (ExpenseModel)dgvExpenses.SelectedRows[0].DataBoundItem;
            UpdateSelected();
        }
    }
}
