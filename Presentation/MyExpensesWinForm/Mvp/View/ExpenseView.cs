/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WinForm.Mvp.View
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using MyExpenses.WinForm.Mvp.Interfaces;
    using MyExpenses.WinForm.Mvp.Model;

    public partial class ExpenseView : Form, IExpenseView
    {
        public ExpenseView()
        {
            InitializeComponent();
            InitEvents();

            txtId.Enabled = false;
        }

        public ICollection<ExpenseModel> Expenses { get; set; }

        public ExpenseModel SelectedExpense { get; set; }

        public event EventHandler UpdateEvent;
        public event EventHandler AddEvent;
        public event EventHandler DeleteEvent;

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
            btnUpdate.Click += BtnUpdateClicked;
            btnAdd.Click += BtnAddClicked;
            btnDelete.Click += BtnDeleteClicked;
        }

        private void UpdateGrid()
        {
            dgvExpenses.DataSource = Expenses;
            dgvExpenses.Columns[0].Visible = false;
        }

        private void UpdateSelected()
        {
            if (SelectedExpense == null)
            { 
                return;
            }

            txtId.Text = SelectedExpense.Id.ToString();
            txtName.Text = SelectedExpense.Name;
            txtValue.Text = $"{SelectedExpense.Value:0.00}";
            txtDate.Text = SelectedExpense.Date.ToShortDateString();
        }

        private void UpdateFooter()
        {
            // Method intentionally left empty.
        }

        private ExpenseModel ConvertViewToModel(bool ignoreId = false)
        {
            return new ExpenseModel
            {
                Id = ignoreId ? 0 : Convert.ToInt16(txtId.Text),
                Name = txtName.Text,
                Value = (float)Convert.ToDouble(txtValue.Text),
                Date = Convert.ToDateTime(txtDate.Text)
            };
        }

        private void DgvExpensesSelectionChanged(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count <= 0)
            { 
                return;
            }

            SelectedExpense = (ExpenseModel)dgvExpenses.SelectedRows[0].DataBoundItem;
            UpdateSelected();
        }

        private void BtnAddClicked(object sender, EventArgs e)
        {
            SelectedExpense = ConvertViewToModel(true);
            AddEvent?.Invoke(sender, e);
        }

        private void BtnUpdateClicked(object sender, EventArgs e)
        {
            SelectedExpense = ConvertViewToModel();
            UpdateEvent?.Invoke(sender, e);
        }

        private void BtnDeleteClicked(object sender, EventArgs e)
        {
            SelectedExpense = ConvertViewToModel();
            DeleteEvent?.Invoke(sender, e);
        }
    }
}
