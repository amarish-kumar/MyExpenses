/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Domain.Models;

    public class ExpenseViewModel
    {
        public ICollection<Expense> Incoming { get; set; }

        public ICollection<Expense> Outcoming { get; set; }

        public Expense Expense { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalIncoming { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalOutcoming { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalLeft { get; set; }
    }
}
