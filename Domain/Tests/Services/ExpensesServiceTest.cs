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
            var obj = _service.GetById(1);
            obj.Name = "NewExpense";

            MyResults results = _service.AddOrUpdate(obj);

            Assert.True(results.Type == MyResultsType.Ok);
            Expense newExpense = _service.GetById(1);
            Assert.True(newExpense.Name == "NewExpense");
        }

        [Test]
        public void TestExpensesServiceGet()
        {
            var obj = _service.Get(x => x.Id == 1).First();

            Assert.True(obj.Equals(_service.GetById(1)));
        }

        [Test]
        public void TestExpensesServiceGetAll()
        {
            var objs = _service.GetAll().ToList();

            Assert.True(objs.Any());
        }

        [Test]
        public void TestExpensesServiceRemove()
        {
            var obj = _service.GetById(2);
            MyResults results = _service.Remove(obj);

            Assert.True(results.Type == MyResultsType.Ok);
            Assert.IsNull(_service.GetById(2));
        }
    }
}
