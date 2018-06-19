/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using global::AutoMapper;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    internal class PaymentAdapter : IPaymentAdapter
    {
        public PaymentDto ModelToDto(Payment model) => Mapper.Map<PaymentDto>(model);

        public Payment DtoToModel(PaymentDto dto) => Mapper.Map<Payment>(dto);
    }
}
