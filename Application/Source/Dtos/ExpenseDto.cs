/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Application.Interfaces.Dtos;

    public class ExpenseDto : IDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Value { get; set; }

        /// <summary>
        /// Dotnet core not handle float values. For that, the value will always get the input without '.' or ',' to separete the decimal.
        /// Pog - Programacao orientada a gambiarra or WOP – Workaround-oriented programming
        /// </summary>
        [Required]
        public int ValuePog
        {
            get => (int)(Value * 100);
            set => Value = (float)value / 100;
        }

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
        public LabelDto Label { get; set; }

        [DisplayName("Payment")]
        public long? PaymentId { get; set; }
        public PaymentDto Payment { get; set; }
    }
}
