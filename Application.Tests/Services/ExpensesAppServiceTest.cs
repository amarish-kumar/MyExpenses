/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Services
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System;
    using System.Linq;

    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private const string NAME = "Expense1";
        private const string NEW_NAME = "NewName";
        private const long ID1 = 1;
        private const long ID2 = 2;

        private static readonly ExpenseDto[] _invalidDtos =
        {
            // invalid id
            new ExpenseDto { Id = -1, Name = NAME, Value = 0, Date = new DateTime() },
            // invalid name
            new ExpenseDto { Id = 1, Name = string.Empty, Value = 0, Date = new DateTime() },
            new ExpenseDto { Id = 1, Name = new string ('a', 129), Value = 0, Date = new DateTime() },
            // invalid value
            new ExpenseDto { Id = 2, Name = NAME, Value = -1, Date = new DateTime() },
            // invalid id, name and value
            new ExpenseDto { Id = -5, Name = null, Value = -10 },
            // default
            new ExpenseDto(),
            // null
            null
        };

        private IExpensesAppService _appService;

        [SetUp]
        public void SetUp()
        {
            MyKernelService.Init();
            MyInfrastructureModule.Init();
            MyApplicationModule.Init();
            MyKernelService.AddModule(new MyApplicationModuleMock());

            _appService = MyKernelService.GetInstance<IExpensesAppService>();
        }

        [Test]
        public void TestExpensesAppService_GetAllExpenses()
        {
            // arrange

            // act
            var dtos = _appService.GetAll(x => x.Tag);

            // assert
            Assert.True(dtos.Any());
        }

        [Test]
        public void TestExpensesAppService_AddOrUpdate_ValidationError([ValueSource(nameof(_invalidDtos))] ExpenseDto dto)
        {
            // arrange

            // act
            var result = _appService.AddOrUpdate(dto);

            // assert
            Assert.AreEqual(result.Status, MyResultsStatus.Error);
            Assert.AreEqual(result.Action, MyResultsAction.Validating);
        }

        [Test]
        public void TestExpensesAppService_GetById_OK()
        {
            // arrange

            // act
            var dto = _appService.Get(x => x.Id == ID1).FirstOrDefault();

            // assert
            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Name, NAME);
        }

        [Test]
        public void TestExpensesAppService_GetById_ErrorNotFind()
        {
            // arrange

            // act
            var dto = _appService.GetById(1000);

            // assert
            Assert.IsNull(dto);
        }

        [Test]
        public void TestExpensesAppService_AddExpense_OK()
        {
            // arrange
            var dto = new ExpenseDto { Id = 0, Name = NEW_NAME, Value = 1, Date = new DateTime() };

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.True(_appService.GetAll().Any(x => x.Name == NEW_NAME));
            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Creating);
        }

        [Test]
        public void TestExpensesAppService_UpdateExpense_OK()
        {
            // arrange
            var dto = _appService.Get(x => x.Id == ID2).First();
            dto.Name = NEW_NAME;

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.True(_appService.GetAll().Any(x => x.Name == NEW_NAME));
            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Updating);
        }

        [Test]
        public void TestExpensesAppService_UpdateExpense_ErroNotFindDomain()
        {
            // arrange
            var dto = new ExpenseDto { Id = 1000 };

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            // arrange
            var dto = _appService.GetById(ID1, x => x.Tag);

            // act
            var results = _appService.Remove(dto);

            // assert
            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_ErrorDomainNotFind()
        {
            // arrange
            var dto = new ExpenseDto { Id = 100 };

            // act
            var results = _appService.Remove(dto);

            // assert
            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_ErrorNull()
        {
            // act
            var results = _appService.Remove(default(ExpenseDto));

            // assert
            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }
    }
}
