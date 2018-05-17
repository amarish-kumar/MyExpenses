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

    internal class PaymentAdapter : IPaymentAdapter
    {
        public PaymentDto ModelToDto(Payment model)
        {
            if (model == null) return null;
            return new PaymentDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public Payment DtoToModel(PaymentDto dto)
        {
            if (dto == null) return null;
            return new Payment
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
