/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Presentaion.WebApplication.ViewModels
{
    using System.Web.Mvc;

    using MyExpenses.Presentaion.WebApplication.Models;

    public class ExpensesViewModel
    {
        public ExpenseModel Model { get; set; }

        public long SelectedTag { get; set; }

        public SelectList AllTags { get; set; }
    }
}