/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Models
{
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Application.Dtos;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class LabelViewModel
    {
        public LabelDto Label { get; set; }

        [DisplayName("#")]
        public int QuantityOfExpenses { get; set; }

        [DisplayName("Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Value { get; set; }
    }

    public class LabelIndexViewModel
    {
        public List<LabelViewModel> Labels { get; set; }

        public LabelViewModel Label { get; set; }

        [DisplayName("Month")]
        public int SelectedMonth { get; set; }

        [DisplayName("Year")]
        public int SelectedYear { get; set; }
    }
}
