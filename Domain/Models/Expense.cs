﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.ComponentModel;
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
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Value { get; set; }

        [Column("Data")]
        [DisplayName("Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Column("Incoming")]
        public int Incoming { get; set; }

        [NotMapped]
        [DisplayName("Incoming/Outcoming")]
        public bool IsIncoming
        {
            get => Incoming == 1;
            set => Incoming = value ? 1 : 0;
        }

        [Column("Fixed")]
        public int InFixed { get; set; }

        [NotMapped]
        [DisplayName("Fixed")]
        public bool IsFixed
        {
            get => InFixed == 1;
            set => InFixed = value ? 1 : 0;
        }

        [ForeignKey("LabelId")]
        [DisplayName("Label")]
        public long? LabelId { get; set; }
        public Label Label { get; set; }

        [ForeignKey("HowId")]
        [DisplayName("How")]
        public long? HowId { get; set; }
        public How How { get; set; }
    }
}
