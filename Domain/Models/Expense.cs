/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expense")]
    public class Expense : ModelBase
    {
        [Required]
        [StringLength(128, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Range(0.0f, float.MaxValue)]
        [DataType(DataType.Currency)]
        public float Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [ForeignKey("LabelId")]
        public Label Label { get; set; }
    }
}
