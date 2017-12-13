/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.MVC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expenses")]
    public class Expenses
    {
        [Key]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Value")]
        public float Value { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
