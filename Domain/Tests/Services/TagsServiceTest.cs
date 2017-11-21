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
    using System.Linq;

    [TestFixture]
    public class TagsServiceTest
    {
        private const long ID1 = 1;
        private const long ID2 = 2;
        private const string NEWNAME = "NewName";

        private ITagsService _service;

        [SetUp]
        public void Setup()
        {
            MyKernelService.Reset();
            MyKernelService.AddModule(new MyDomainModuleMock());

            _service = MyKernelService.GetInstance<TagsService>();
        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
        }


        [Test]
        public void TestTagsService_GetAll()
        {
            var objs = _service.GetAll();

            Assert.True(objs.Any());
        }

        [Test]
        public void TestTagsService_Get()
        {
            var obj1 = _service.Get(x => x.Id == ID1).First();
            var obj2 = _service.GetById(ID1).MyClone();

            Assert.True(obj1.Equal(obj2));
            Assert.True(obj1.Equals(obj2));
            Assert.True(obj1.MyEqual(obj2));
        }

        [Test]
        public void TestTagsService_Add_Ok()
        {
            var obj = _service.GetById(ID1).MyClone();
            obj.Id = 0;
            obj.Name = NEWNAME;

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Creating);

            obj = _service.Get(x => x.Name == NEWNAME).First();
            Assert.IsNotNull(obj);
        }

        [Test]
        public void TestTagsService_Update_Ok()
        {
            var obj = _service.GetById(ID1);
            obj.Name = NEWNAME;

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Updating);

            var newObj = _service.GetById(ID1);
            Assert.AreEqual(newObj.Name, NEWNAME);
        }

        [Test]
        public void TestTagsService_Update_ErrorNotFind()
        {
            var obj = _service.GetById(ID1).MyClone();
            obj.Id = 1000;
            obj.Name = NEWNAME;

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Updating);
        }

        [Test]
        public void TestTagsService_Add_ErrorValidation()
        {
            var obj = new Tag();
            obj.Copy(_service.GetById(ID1));
            obj.Id = 0;
            obj.Name = "";

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
        }

        [Test]
        public void TestTagsService_Remove_Ok()
        {
            MyResults results = _service.Remove(_service.GetById(ID1));

            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);

            Assert.IsNull(_service.GetById(ID1));

            // confirm that removed from expenses
            var expensesService = MyKernelService.GetInstance<ExpensesService>();
            Assert.IsFalse(expensesService.GetAll().Any(x => x.Tags.Any(y => y.Id == ID1)));
        }

        [Test]
        public void TestTagsService_Remove_ErrorNotFind()
        {
            var obj = new Tag();
            obj.Copy(_service.GetById(ID1));
            obj.Id = 1000;

            MyResults results = _service.Remove(obj);

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }
    }
}
