/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;

    public class PaymentAppService : AppServiceBase<Payment>, IPaymentAppService
    {
        public PaymentAppService(IAppService<Payment> service, IUnitOfWork unitOfWork)
            : base(service, unitOfWork)
        {
        }
    }
}
