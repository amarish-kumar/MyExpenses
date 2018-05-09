/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class PaymentService : ServiceBase<Payment>, IPaymentService
    {
        private readonly IExpenseService _expenseService;

        public PaymentService(IPaymentRepository repository, IExpenseService expenseService)
            : base(repository)
        {
            _expenseService = expenseService;
        }

        public override bool Remove(long id)
        {
            _expenseService.RemovePaymentFromExpenses(id);

            return base.Remove(id);
        }

        public override bool Remove(Payment model)
        {
            _expenseService.RemovePaymentFromExpenses(model.Id);

            return base.Remove(model);
        }
    }
}
