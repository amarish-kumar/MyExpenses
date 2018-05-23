/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.ApplicationTest
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Application.Adapters;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Services;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;

    [TestClass]
    public class ServicesTest
    {
        private IServiceCollection _servicesCollection;
        private IExpenseAppService _expenseAppService;

        [TestInitialize]
        public void Initialize()
        {
            _servicesCollection = new ServiceCollection();

            _servicesCollection.AddDbContext<MyExpensesContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            _servicesCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            _servicesCollection.AddScoped<IExpenseRepository, ExpenseRepository>();
            _servicesCollection.AddScoped<ILabelRepository, LabelRepository>();
            _servicesCollection.AddScoped<IPaymentRepository, PaymentRepository>();

            // Domain Services
            _servicesCollection.AddScoped<IExpenseService, ExpenseService>();
            _servicesCollection.AddScoped<ILabelService, LabelService>();
            _servicesCollection.AddScoped<IPaymentService, PaymentService>();

            // Application services
            _servicesCollection.AddScoped<IExpenseAppService, ExpenseAppService>();
            _servicesCollection.AddScoped<ILabelAppService, LabelAppService>();
            _servicesCollection.AddScoped<IPaymentAppService, PaymentAppService>();

            // Adapters
            _servicesCollection.AddScoped<IExpenseAdapter, ExpenseAdapter>();
            _servicesCollection.AddScoped<ILabelAdapter, LabelAdapter>();
            _servicesCollection.AddScoped<IPaymentAdapter, PaymentAdapter>();

            ServiceProvider serviceProvider = _servicesCollection.BuildServiceProvider();

            _expenseAppService = serviceProvider.GetRequiredService<IExpenseAppService>();

            _expenseAppService.AddOrUpdate(new ExpenseDto { Name = "Expense1", Value = 1.1f, Data = DateTime.Now });
        }

        [TestCleanup]
        public void CleanUp()
        {
            _servicesCollection.Clear();
            _servicesCollection = null;

            _expenseAppService = null;
        }

        [TestMethod]
        public void Dummy()
        {
            var allExpenses = _expenseAppService.GetAll().ToList();
            Assert.IsTrue(allExpenses.Any());
        }
    }
}
