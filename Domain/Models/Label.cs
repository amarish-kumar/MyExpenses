/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Label")]
    public class Label : ModelBase
    {
        [Required]
        [StringLength(128, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
