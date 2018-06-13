/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class IndexExpenseDto
    {
        public List<ExpenseDto> Incoming { get; set; }

        public List<ExpenseDto> Outcoming { get; set; }

        public ExpenseDto Expense { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalIncoming => Incoming.Sum(x => x.Value);

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalOutcoming => Outcoming.Sum(x => x.Value);

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalLeft => TotalIncoming - TotalOutcoming;
    }
}
