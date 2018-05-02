/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

using MyExpenses.Application.Dtos;
using MyExpenses.Domain.Models;

namespace MyExpenses.Application.Adapters
{
    public class ExpenseAdapter : IExpenseAdapter
    {
        public ExpenseDto ModelToDto(Expense model)
        {
            return new ExpenseDto
            {
                Id = model.Id,
                Name = model.Name,
                Value = model.Value,
                Data = model.Data,
                IsIncoming = model.IsIncoming,
                LabelId = model.LabelId,
                Label = model.Label,
                PaymentId = model.PaymentId,
                Payment = model.Payment
            };
        }

        public Expense DtoToModel(ExpenseDto dto)
        {
            return new Expense
            {
                Id = dto.Id,
                Name = dto.Name,
                Value = dto.Value,
                Data = dto.Data,
                IsIncoming = dto.IsIncoming,
                LabelId = dto.LabelId,
                Label = dto.Label,
                PaymentId = dto.PaymentId,
                Payment = dto.Payment
            };
        }
    }
}
