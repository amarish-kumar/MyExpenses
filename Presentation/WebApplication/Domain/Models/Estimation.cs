/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Estimation")]
    public class Estimation : ModelBase
    {
        [Required]
        [ForeignKey("TypeId")]
        public Type Type { get; set; }

        [Required]
        [Range(0.0f, float.MaxValue)]
        [DataType(DataType.Currency)]
        public float Value { get; set; }
    }
}
