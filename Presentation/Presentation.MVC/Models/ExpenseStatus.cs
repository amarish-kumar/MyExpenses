/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.MVC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExpenseStatus")]
    public class ExpenseStatus
    {
        [Key]
        public long Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
