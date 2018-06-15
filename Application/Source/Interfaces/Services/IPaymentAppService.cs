/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Application.Dtos;

    public interface IPaymentAppService : IAppService<PaymentDto>
    {
        IEnumerable<IndexPaymentDto> Get(DateTime starDateTime, DateTime endDateTime);
    }
}
