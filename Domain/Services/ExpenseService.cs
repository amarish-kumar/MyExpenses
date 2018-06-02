/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;
    

    public class ExpenseService : ServiceBase<Expense>, IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Expense> GetAllIncoming(DateTime startTime, DateTime endTime)
        {
            return _repository
                .GetAll(x => x.Label, x => x.Payment)
                .Where(x => x.IsIncoming && x.Data >= startTime && x.Data < endTime);
        }

        public IEnumerable<Expense> GetAllOutcoming(DateTime startTime, DateTime endTime)
        {
            return _repository
                .GetAll(x => x.Label, x => x.Payment)
                .Where(x => !x.IsIncoming && x.Data >= startTime && x.Data < endTime);
        }

        public void RemoveLabelFromExpenses(long labelId)
        {
            _repository.Get(x => x.LabelId == labelId, x => x.Label)
                .ToList()
                .ForEach(expense =>
                    {
                        expense.LabelId = null;
                        expense.Label = null;
                        _repository.AddOrUpdate(expense);
                    });
        }

        public void RemovePaymentFromExpenses(long paymentId)
        {
            _repository.Get(x => x.PaymentId == paymentId, x => x.Payment)
                .ToList()
                .ForEach(expense =>
                    {
                        expense.PaymentId = null;
                        expense.Payment = null;
                        _repository.AddOrUpdate(expense);
                    });
        }
    }
}
