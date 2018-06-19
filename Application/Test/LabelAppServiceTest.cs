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
    public class LabelAppServiceTest : TestBase
    {
        private const float TOLERANCE = 0.001f;

        private ILabelAppService _appService;

        [TestInitialize]
        public void Initialize()
        {
            _appService = GetAppService<ILabelAppService>();
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
            var obj = _appService.GetById(id);

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
        public void GetWithWrongDate()
        {
            var start = Util.MyDate.GetStartDateTime(1, 2010);
            var end = Util.MyDate.GetEndDateTime(1, 2010);

            var objs = _appService.Get(start, end).ToList();

            Assert.IsTrue(objs.Any());
            objs.ForEach(x =>
                {
                    Assert.AreEqual(0, x.Amount);
                    Assert.AreEqual(0, x.LastMonth);
                    Assert.AreEqual(0, x.Value);
                    Assert.AreEqual(0, x.Average);
                });
        }

        [TestMethod]
        public void GetWithCorrectDate()
        {
            var start = Util.MyDate.GetStartDateTime(DateTime.Today);
            var end = Util.MyDate.GetEndDateTime(DateTime.Today);

            var objs = _appService.Get(start, end).ToList();

            Assert.IsTrue(objs.Any());
            objs.ForEach(x => 
                {
                    Assert.AreNotEqual(0, x.Amount);
                    Assert.AreEqual(0, x.LastMonth);
                    Assert.AreNotEqual(0, x.Value);
                    Assert.AreEqual(0, x.Average);
                });
        }
    }
}