/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Domain.Models;
    using System.ComponentModel;
    using System;

    public class ExpenseViewModel
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

        public ExpenseViewModel()
        {
                
        }

        public ExpenseViewModel(Expense expense)
        {
            Id = expense.Id;
            Name = expense.Name;
            Value = expense.Value;
            Data = expense.Data;
            IsIncoming = expense.IsIncoming;
            LabelId = expense.LabelId;
            Label = expense.Label;
            PaymentId = expense.PaymentId;
            Payment = expense.Payment;
        }

        public Expense ToModel()
        {
            return new Expense
            {
                Id = Id,
                Name = Name,
                Value = Value,
                Data = Data,
                IsIncoming = IsIncoming,
                LabelId = LabelId < 0 ? null : LabelId,
                Label = Label,
                PaymentId = PaymentId < 0 ? null : PaymentId,
                Payment = Payment
            };
        }
    }

    public class IndexExpenseViewModel
    {
        public ICollection<ExpenseViewModel> Incoming { get; set; }

        public ICollection<ExpenseViewModel> Outcoming { get; set; }

        public ExpenseViewModel Expense { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalIncoming { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalOutcoming { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float TotalLeft { get; set; }
    }
}
