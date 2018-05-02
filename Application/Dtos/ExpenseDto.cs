/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using MyExpenses.Domain.Models;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ExpenseDto : IDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Value { get; set; }

        [DisplayName("Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public int Incoming { get; set; }

        [DisplayName("Incoming")]
        public bool IsIncoming
        {
            get => Incoming == 1;
            set => Incoming = value ? 1 : 0;
        }

        [DisplayName("Label")]
        public long? LabelId { get; set; }
        public Label Label { get; set; }

        [DisplayName("Payment")]
        public long? PaymentId { get; set; }
        public Payment Payment { get; set; }

        public ExpenseDto()
        {

        }
    }
}
