/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.DomainTest
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    [TestClass]
    public class ExpenseServiceTest : ServiceTestBase<Expense, IExpenseService>
    {
        [TestInitialize]
        public void Initialize()
        {
            Service = GetAppService<IExpenseService>();
            UnitOfWork = GetAppService<IUnitOfWork>();
            ModelBase = new Expense { Name = "Test" };
        }

        [TestMethod]
        public void ExpenseTestGetWithInclude()
        {
            // arrange

            // act
            var allObjs = Service.Get(x => x.Label, x => x.Payment).ToList();

            // assert
            Assert.IsTrue(allObjs.Any());
            allObjs.ForEach(x =>
                {
                    Assert.IsNotNull(x.Label);
                    Assert.IsTrue(x.Label.Expenses.Any());

                    Assert.IsNotNull(x.Payment);
                    Assert.IsTrue(x.Payment.Expenses.Any());
                });
        }

        [TestMethod]
        public void ExpenseTestGetByIdWithInclude()
        {
            // arrange

            // act
            var obj = Service.GetById(1, x => x.Label, x => x.Payment);

            // assert
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Label);
            Assert.IsTrue(obj.Label.Expenses.Any());
            Assert.IsNotNull(obj.Payment);
            Assert.IsTrue(obj.Payment.Expenses.Any());
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void ExpenseTestGetAllIncoming(bool isIncoming)
        {
            // arrange
            var start = Util.MyDate.GetStartDateTime(DateTime.Today);
            var end = Util.MyDate.GetEndDateTime(DateTime.Today);

            // act
            var objs = isIncoming ? 
                           Service.GetAllIncoming(start, end).ToList() :
                           Service.GetAllOutcoming(start, end).ToList();

            // assert
            Assert.IsTrue(objs.Any());
            objs.ForEach(x =>
                {
                    Assert.AreEqual(isIncoming, x.IsIncoming);

                    Assert.IsNotNull(x.Label);
                    Assert.IsTrue(x.Label.Expenses.Any());

                    Assert.IsNotNull(x.Payment);
                    Assert.IsTrue(x.Payment.Expenses.Any());
                });
        }
    }
}