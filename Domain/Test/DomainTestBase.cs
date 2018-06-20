/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.DomainTest
{
    using System;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Application.Modules;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;

    public abstract class DomainTestBase
    {
        private const int NUMBER_OBJ = 10;

        private IServiceCollection _servicesCollection;
        private ServiceProvider _serviceProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            Init();
            Fill();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _servicesCollection.Clear();
            _servicesCollection = null;

            _serviceProvider?.Dispose();
            _serviceProvider = null;
        }

        private void Init()
        {
            _servicesCollection = new ServiceCollection();

            // mock with memory database
            _servicesCollection.AddDbContext<MyExpensesContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            
            // configure all others projects
            DomainModule.ConfigureServices(_servicesCollection);
            InfrastructureModule.ConfigureServices(_servicesCollection);

            // build
            _serviceProvider = _servicesCollection.BuildServiceProvider();
        }

        private void Fill()
        {
            var unitOfWork = GetAppService<IUnitOfWork>();
            unitOfWork.BeginTransaction();

            var labels = new List<Label>();
            var payments = new List<Payment>();

            ILabelService labelService = GetAppService<ILabelService>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                labels.Add(labelService.Add(new Label { Name = $"Label{i + 1}" }));
            }

            IPaymentService paymentService = GetAppService<IPaymentService>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                payments.Add(paymentService.Add(new Payment { Name = $"Payment{i + 1}" }));
            }

            IExpenseService expenseService = GetAppService<IExpenseService>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                expenseService.Add(new Expense
                {
                    Name = $"Expense{i + 1}",
                    Data = DateTime.Today,
                    Value = i + 1,
                    Label = labels[i],
                    LabelId = labels[i].Id,
                    Payment = payments[i],
                    PaymentId = payments[i].Id,
                    IsIncoming = i % 2 == 0
                });
            }

            unitOfWork.Commit();
        }

        protected T GetAppService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
