/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class IndexLabelDto
    {
        public LabelDto Label { get; set; }

        [DisplayName("#")]
        public int Amount { get; set; }

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
