/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Application.Dtos;

    public class LabelViewModel
    {
        public LabelDto Label { get; set; }

        [DisplayName("#")]
        public int QuantityOfExpenses { get; set; }

        [DisplayName("Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Value { get; set; }

        [DisplayName("Last Month")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float LastMonth { get; set; }

        [DisplayName("Average")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Average { get; set; }
    }
}
