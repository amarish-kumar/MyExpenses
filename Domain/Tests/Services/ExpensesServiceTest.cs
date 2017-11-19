/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Services
{
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Services;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExpensesServiceTest
    {
        private IExpensesService _service;

        [SetUp]
        public void Setup()
        {
            MyKernelService.Init();
            MyKernelService.AddModule(new MyDomainModuleMock());

            _service = MyKernelService.GetInstance<ExpensesService>();
        }

        [Test]
        public void TestExpensesServiceSaveAndUpdate()
        {
            Expense expense = _service.GetById(1);
            expense.Name = "NewExpense";

            MyResults results = _service.AddOrUpdate(expense);

            Assert.True(results.Type == MyResultsType.Ok);
            Expense newExpense = _service.GetById(1);
            Assert.True(newExpense.Name == "NewExpense");
        }

        [Test]
        public void TestExpensesServiceGet()
        {
            List<Expense> expenses = _service.Get(x => x.Id == 1).ToList();

            Assert.True(expenses.Any());
        }

        [Test]
        public void TestExpensesServiceGetAll()
        {
            List<Expense> expenses = _service.GetAll().ToList();

            Assert.True(expenses.Any());
        }

        [Test]
        public void TestExpensesServiceRemove()
        {
            Expense expense = _service.GetById(2);
            MyResults results = _service.Remove(expense);

            Assert.True(results.Type == MyResultsType.Ok);
            Assert.IsNull(_service.GetById(2));
        }
    }
}
