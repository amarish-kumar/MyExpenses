/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.Interfaces;

    [Table("Expense")]
    public class Expense : ModelBase
    {
        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Data { get; set; }

        [Column("Incoming")]
        public int Incoming { get; set; }

        [NotMapped]
        public bool IsIncoming
        {
            get => Incoming == 1;
            set => Incoming = value ? 1 : 0;
        }

        [ForeignKey("LabelId")]
        public long? LabelId { get; set; }
        public Label Label { get; set; }

        [ForeignKey("PaymentId")]
        public long? PaymentId { get; set; }
        public Payment Payment { get; set; }

        public override void Copy(IModel obj)
        {
            base.Copy(obj);

            if (obj is Expense expense)
            {
                Name = expense.Name;
                Value = expense.Value;
                Data = expense.Data;
                IsIncoming = expense.IsIncoming;

                LabelId = expense.LabelId;
                Label = expense.Label;

                PaymentId = expense.PaymentId;
                Payment = expense.Payment;
            }
        }
    }
}
