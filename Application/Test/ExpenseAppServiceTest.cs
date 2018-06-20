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
            // arrange

            // act
            var all = _appService.Get();

            // assert
            Assert.IsTrue(all.Any());
        }

        [TestMethod]
        public void UpdateAllNames()
        {
            // arrange
            var all = _appService.Get().ToList();

            for (int i = 0; i < all.Count; i++)
            {
                all[i].Name = string.Format(Resource.NewName, i);
            }

            // act
            all.ForEach(x => _appService.Update(x));
            
            // act
            for (int i = 0; i < _appService.Get().ToList().Count; i++)
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
            // arrange
            var first = _appService.Get().First();

            // act
            first.Id = id;

            // assert
            Assert.IsNull(_appService.Update(first));
        }

        [TestMethod]
        public void UpdateNullObject()
        {
            // arrange

            // act
            var obj = _appService.Update(null);

            // assert
            Assert.IsNull(obj);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void RemoveObject(int id)
        {
            // arrange

            // act
            var removed = _appService.Remove(id);

            // assert
            Assert.IsTrue(removed);
            Assert.IsNull(_appService.GetById(id));
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void RemoveNonExistingObject(int id)
        {
            // arrange
            var first = _appService.Get().First();
            first.Id = id;

            // act
            var removed = _appService.Remove(id);

            // assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void GetAllYears()
        {
            // arrange

            // act
            var allYears = _appService.GetAllYears();

            // assert
            Assert.IsTrue(allYears.Any());
            Assert.AreEqual(DateTime.Today.Year, allYears.First());
        }

        [TestMethod]
        public void GetIndexExpensesCorrectDate()
        {
            // arrange
            var start = Util.MyDate.GetStartDateTime(DateTime.Today);
            var end = Util.MyDate.GetEndDateTime(DateTime.Today);

            // act
            var indexExpenses = _appService.GetIndexExpenses(start, end);

            // assert
            Assert.IsTrue(indexExpenses.Incoming.Any());
            Assert.IsTrue(indexExpenses.Outcoming.Any());
            Assert.AreNotEqual(0, indexExpenses.TotalIncoming);
            Assert.AreNotEqual(0, indexExpenses.TotalOutcoming);
            Assert.AreNotEqual(0, indexExpenses.TotalLeft);
        }

        [TestMethod]
        public void GetIndexExpensesWithWrongDate()
        {
            // arrange
            var start = Util.MyDate.GetStartDateTime(1, 2010);
            var end = Util.MyDate.GetStartDateTime(1, 2010);

            // act
            var indexExpenses = _appService.GetIndexExpenses(start, end);

            // assert
            Assert.IsFalse(indexExpenses.Incoming.Any());
            Assert.IsFalse(indexExpenses.Outcoming.Any());
            Assert.AreEqual(0, indexExpenses.TotalIncoming);
            Assert.AreEqual(0, indexExpenses.TotalOutcoming);
            Assert.AreEqual(0, indexExpenses.TotalLeft);
        }

        [TestMethod]
        public void UpdateLabel()
        {
            // arrange
            var first = _appService.Get().First();
            var last = _appService.Get().Last();
            first.LabelId = last.LabelId;

            // act
            _appService.Update(first);
            first = _appService.GetById(first.Id);

            // assert
            Assert.AreEqual(first.LabelId, last.LabelId);
        }

        [TestMethod]
        public void UpdatePayment()
        {
            // arrange
            var first = _appService.Get().First();
            var last = _appService.Get().Last();
            first.PaymentId = last.PaymentId;

            // act
            _appService.Update(first);
            first = _appService.GetById(first.Id);

            // assert
            Assert.AreEqual(first.PaymentId, last.PaymentId);
        }
    }
}