/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.InfrastructureTest
{
    using System;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Application.Modules;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.InfrastructureTest.Properties;

    public abstract class InfrastructureTestBase
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

            var labelRepository = GetAppService<ILabelRepository>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                labels.Add(labelRepository.Add(new Label { Name = string.Format(Resource.LabelName, i + 1) }));
            }

            var paymentRepository = GetAppService<IPaymentRepository>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                payments.Add(paymentRepository.Add(new Payment { Name = string.Format(Resource.PaymentName, i + 1) }));
            }

            var expenseRepository = GetAppService<IExpenseRepository>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                expenseRepository.Add(new Expense
                {
                    Name = string.Format(Resource.PaymentName, i + 1),
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
