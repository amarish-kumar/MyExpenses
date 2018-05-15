/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Application.Dtos;

    public class IndexExpenseViewModel
    {
        public List<ExpenseDto> Incoming { get; set; }

        public List<ExpenseDto> Outcoming { get; set; }

        public ExpenseDto Expense { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

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
