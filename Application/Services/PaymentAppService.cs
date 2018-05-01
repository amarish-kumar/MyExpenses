/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class PaymentAppService : AppServiceBase<Payment>, IPaymentAppService
    {
        public PaymentAppService(IPaymentService service, IUnitOfWork unitOfWork)
            : base(service, unitOfWork)
        {
        }
    }
}
