/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.ApplicationTest
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.ApplicationTest.Properties;

    [TestClass]
    public class ExpenseAppServiceTest : ApplicationTestBase
    {
        private IExpenseAppService _appService;

        [TestInitialize]
        public void Initialize()
        {
            _appService = GetAppService<IExpenseAppService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _appService = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            var all = _appService.Get();

            Assert.IsTrue(all.Any());
        }

        [TestMethod]
        public void UpdateAllNames()
        {
            var all = _appService.Get().ToList();

            // update model
            for (int i = 0; i < all.Count; i++)
            {
                all[i].Name = string.Format(Resource.NewName, i);
            }

            // update database
            all.ForEach(x => _appService.Update(x));

            // get again
            all = _appService.Get().ToList();

            // check if all expenses were updated
            // update model
            for (int i = 0; i < all.Count; i++)
            {
                Assert.AreEqual(string.Format(Resource.NewName, i), all[i].Name);
            }
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void UpdateNonExistingObject(int id)
        {
            var first = _appService.Get().First();

            first.Id = id;

            Assert.IsNull(_appService.Update(first));
        }

        [TestMethod]
        public void UpdateNullObject()
        {
            Assert.IsNull(_appService.Update(null));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void RemoveObject(int id)
        {
            Assert.IsTrue(_appService.Remove(id));
            Assert.IsNull(_appService.GetById(id));
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void RemoveNonExistingObject(int id)
        {
            var first = _appService.Get().First();

            first.Id = id;

            Assert.IsFalse(_appService.Remove(id));
        }

        [TestMethod]
        public void GetAllYears()
        {
            var allYears = _appService.GetAllYears();

            Assert.IsTrue(allYears.Any());
            Assert.AreEqual(DateTime.Today.Year, allYears.First());
        }

        [TestMethod]
        public void GetIndexExpensesCorrectDate()
        {
            var start = Util.MyDate.GetStartDateTime(DateTime.Today);
            var end = Util.MyDate.GetEndDateTime(DateTime.Today);

            var indexExpenses = _appService.GetIndexExpenses(start, end);

            Assert.IsTrue(indexExpenses.Incoming.Any());
            Assert.IsTrue(indexExpenses.Outcoming.Any());
            Assert.AreNotEqual(0, indexExpenses.TotalIncoming);
            Assert.AreNotEqual(0, indexExpenses.TotalOutcoming);
            Assert.AreNotEqual(0, indexExpenses.TotalLeft);
        }

        [TestMethod]
        public void GetIndexExpensesWithWrongDate()
        {
            var start = Util.MyDate.GetStartDateTime(1, 2010);
            var end = Util.MyDate.GetStartDateTime(1, 2010);

            var indexExpenses = _appService.GetIndexExpenses(start, end);

            Assert.IsFalse(indexExpenses.Incoming.Any());
            Assert.IsFalse(indexExpenses.Outcoming.Any());
            Assert.AreEqual(0, indexExpenses.TotalIncoming);
            Assert.AreEqual(0, indexExpenses.TotalOutcoming);
            Assert.AreEqual(0, indexExpenses.TotalLeft);
        }

        [TestMethod]
        public void UpdateLabel()
        {
            var first = _appService.Get().First();
            var last = _appService.Get().Last();

            first.LabelId = last.LabelId;

            _appService.Update(first);

            first = _appService.GetById(first.Id);

            Assert.AreEqual(first.LabelId, last.LabelId);
        }

        [TestMethod]
        public void UpdatePayment()
        {
            var first = _appService.Get().First();
            var last = _appService.Get().Last();

            first.PaymentId = last.PaymentId;

            _appService.Update(first);

            first = _appService.GetById(first.Id);

            Assert.AreEqual(first.PaymentId, last.PaymentId);
        }
    }
}