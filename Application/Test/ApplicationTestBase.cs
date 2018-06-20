/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.ApplicationTest
{
    using System;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Context;

    public abstract class ApplicationTestBase
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
            ApplicationModule.ConfigureServices(_servicesCollection);

            // build
            _serviceProvider = _servicesCollection.BuildServiceProvider();
        }

        private void Fill()
        {
            var labelsDto = new List<LabelDto>();
            var paymentDto = new List<PaymentDto>();

            ILabelAppService labelAppService = GetAppService<ILabelAppService>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                labelsDto.Add(labelAppService.Add(new LabelDto { Name = $"Label{i + 1}" }));
            }

            IPaymentAppService paymentAppService = GetAppService<IPaymentAppService>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                paymentDto.Add(paymentAppService.Add(new PaymentDto { Name = $"Payment{i + 1}" }));
            }

            IExpenseAppService expenseAppService = GetAppService<IExpenseAppService>();
            for (int i = 0; i < NUMBER_OBJ; i++)
            {
                expenseAppService.Add(new ExpenseDto
                {
                    Name = $"Expense{i + 1}",
                    Data = DateTime.Today,
                    Value = i + 1,
                    Label = labelsDto[i],
                    LabelId = labelsDto[i].Id,
                    Payment = paymentDto[i],
                    PaymentId = paymentDto[i].Id,
                    IsIncoming = i % 2 == 0
                });
            }
        }

        protected T GetAppService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
