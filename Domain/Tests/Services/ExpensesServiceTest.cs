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
    public class ExpensesServiceTest
    {
        private const long ID = 1;
        private const string NEWNAME = "NewName";

        private IExpensesService _service;

        [SetUp]
        public void Setup()
        {
            MyKernelService.Reset();
            MyKernelService.AddModule(new MyDomainModuleMock());

            _service = MyKernelService.GetInstance<ExpensesService>();
        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
        }

        [Test]
        public void TestExpensesService_GetAll()
        {
            var objs = _service.GetAll(x => x.Tags);

            Assert.True(objs.Any());
        }

        [Test]
        public void TestExpensesService_Get()
        {
            var obj = _service.Get(x => x.Id == ID, x => x.Tags).First();

            Assert.True(obj.Equals(_service.GetById(ID)));
        }

        [Test]
        public void TestExpensesService_Add_Ok()
        {
            var obj = new Expense();
            obj.Copy(_service.GetById(1));
            obj.Id = 0;
            obj.Name = NEWNAME;

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Type, MyResultsType.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Creating);

            obj = _service.Get(x => x.Name == NEWNAME).First();
            Assert.IsNotNull(obj);
        }

        [Test]
        public void TestExpensesService_Update_Ok()
        {
            var obj = _service.GetById(ID);
            obj.Name = NEWNAME;

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Type, MyResultsType.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Updating);

            var newObj = _service.GetById(ID);
            Assert.AreEqual(newObj.Name, NEWNAME);
        }

        [Test]
        public void TestExpensesService_Add_ErrorValidation()
        {
            var obj = new Expense();
            obj.Copy(_service.GetById(ID));
            obj.Id = 0;
            obj.Name = "";

            MyResults results = _service.AddOrUpdate(obj);

            Assert.AreEqual(results.Type, MyResultsType.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
        }

        [Test]
        public void TestExpensesService_Remove_Ok()
        {
            MyResults results = _service.Remove(_service.GetById(ID));

            Assert.AreEqual(results.Type, MyResultsType.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);

            Assert.IsNull(_service.GetById(ID));
        }

        [Test]
        public void TestExpensesService_Remove_ErrorNotFind()
        {
            var obj = new Expense();
            obj.Copy(_service.GetById(ID));
            obj.Id = 1000;

            MyResults results = _service.Remove(obj);

            Assert.AreEqual(results.Type, MyResultsType.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }
    }
}
