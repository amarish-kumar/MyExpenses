/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    public class ExpenseAdapter : IExpenseAdapter
    {
        private readonly ILabelAdapter _labelAdapter;
        private readonly IPaymentAdapter _paymentAdapter;

        public ExpenseAdapter(ILabelAdapter labelAdapter, IPaymentAdapter paymentAdapter)
        {
            _labelAdapter = labelAdapter;
            _paymentAdapter = paymentAdapter;
        }

        public ExpenseDto ModelToDto(Expense model)
        {
            if (model == null) return null;
            return new ExpenseDto
            {
                Id = model.Id,
                Name = model.Name,
                Value = model.Value,
                Data = model.Data,
                IsIncoming = model.IsIncoming,
                LabelId = model.LabelId,
                Label = _labelAdapter.ModelToDto(model.Label),
                PaymentId = model.PaymentId,
                Payment = _paymentAdapter.ModelToDto(model.Payment)
            };
        }

        public Expense DtoToModel(ExpenseDto dto)
        {
            if (dto == null) return null;
            return new Expense
            {
                Id = dto.Id,
                Name = dto.Name,
                Value = dto.Value,
                Data = dto.Data,
                IsIncoming = dto.IsIncoming,
                LabelId = dto.LabelId,
                Label = _labelAdapter.DtoToModel(dto.Label),
                PaymentId = dto.PaymentId,
                Payment = _paymentAdapter.DtoToModel(dto.Payment)
            };
        }
    }
}
