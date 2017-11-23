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
        private const long ID = 1;

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

        private readonly ExpenseDto _validDto = new ExpenseDto { Id = 10, Name = "tmp", Value = 1, Date = new DateTime() };

        private IExpensesAppService _appService;

        [SetUp]
        public void SetUp()
        {
            MyKernelService.Reset();
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
            var dtos = _appService.GetAll();

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
            var dto = _appService.GetById(ID);

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
        public void TestExpensesAppService_SaveExpense_OK()
        {
            // arrange
            var dto = _validDto;
            dto.Id = 0;
            dto.Name = NEW_NAME;

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.True(_appService.GetAll().Any(x => x.Name == NEW_NAME));
            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Creating);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            // arrange
            var dto = _appService.GetById(ID);

            // act
            var results = _appService.Remove(dto);

            // assert
            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_Error()
        {
            // arrange
            var dto = new ExpenseDto { Id = 100 };

            // act
            var results = _appService.Remove(dto);

            // assert
            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Removing);
        }
    }
}
