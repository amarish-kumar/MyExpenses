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
    using MyExpenses.Application.ViewModels;

    public interface IPaymentAppService : IAppService<PaymentDto>
    {
        IEnumerable<PaymentViewModel> GetAll(DateTime starDateTime, DateTime endDateTime);
    }
}
