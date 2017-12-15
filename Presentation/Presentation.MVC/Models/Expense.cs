/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.MVC.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expense")]
    public class Expense
    {
        [Key]
        public long Id { get; set; }

        [Column("Name")]
        [DisplayName("Name")]
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Column("Value")]
        [DisplayName("Price")]
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:€#.00}")]
        public float Value { get; set; }

        [Column("Data")]
        [DisplayName("Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Column("Income")]
        [DisplayName("Income")]
        public int Income { get; set; }

        [Column("SplitAmount")]
        [DisplayName("Split Amount")]
        public int SplitAmount { get; set; }

        [Column("SplitCurrent")]
        public int SplitCurrent { get; set; }

        public long? ExpenseTagId { get; set; }

        [ForeignKey("ExpenseTagId")]
        public virtual ExpenseTag ExpenseTag { get; set; }

        public long? ExpenseHowId { get; set; }

        [ForeignKey("ExpenseHowId")]
        public virtual ExpenseHow ExpenseHow { get; set; }

        public long? ExpenseStatusId { get; set; }

        [ForeignKey("ExpenseStatusId")]
        public virtual ExpenseStatus ExpenseStatus { get; set; }
    }
}
