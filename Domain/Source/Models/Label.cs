/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using MyExpenses.Domain.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Label")]
    public class Label : ModelBase
    {
        [Required]
        [StringLength(128, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public override void Copy(IModel obj)
        {
            base.Copy(obj);

            if (obj is Label label)
            {
                Name = label.Name;
            }
        }
    }
}
