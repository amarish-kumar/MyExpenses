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
    using System;
    using System.Linq;

    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;
    using Xunit;

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

        //[SetUp]
        public ExpensesAppServiceTest()
        {
            MyKernelService.Reset();
            MyInfrastructureModule.Init();
            MyApplicationModule.Init();
            MyKernelService.AddModule(new MyApplicationModuleMock());

            _appService = MyKernelService.GetInstance<IExpensesAppService>();
        }

        [Fact]
        public void TestExpensesAppService_GetAllExpenses()
        {
            // arrange

            // act
            var dtos = _appService.GetAll(x => x.Tag);

            // assert
            Assert.True(dtos.Any());
        }

        //[Test]
        //public void TestExpensesAppService_AddOrUpdate_ValidationError([ValueSource(nameof(_invalidDtos))] ExpenseDto dto)
        //{
        //    // arrange

        //    // act
        //    var result = _appService.AddOrUpdate(dto);

        //    // assert
        //    Assert.AreEqual(result.Status, MyResultsStatus.Error);
        //    Assert.AreEqual(result.Action, MyResultsAction.Validating);
        //}

        [Fact]
        public void TestExpensesAppService_GetById_OK()
        {
            // arrange

            // act
            var dto = _appService.GetById(ID);

            // assert
            Assert.NotNull(dto);
            Assert.Equal(dto.Name, NAME);
        }

        [Fact]
        public void TestExpensesAppService_GetById_ErrorNotFind()
        {
            // arrange

            // act
            var dto = _appService.GetById(1000);

            // assert
            Assert.Null(dto);
        }

        [Fact]
        public void TestExpensesAppService_AddExpense_OK()
        {
            // arrange
            var dto = _validDto;
            dto.Id = 0;
            dto.Name = NEW_NAME;

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.Contains(_appService.GetAll(), x => x.Name == NEW_NAME);
            Assert.Equal(MyResultsStatus.Ok, results.Status);
            Assert.Equal(MyResultsAction.Creating, results.Action);
        }

        [Fact]
        public void TestExpensesAppService_UpdateExpense_OK()
        {
            // arrange
            var dto = _appService.Get(x => x.Id == ID, x => x.Tag).First();
            dto.Name = NEW_NAME;

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.Contains(_appService.GetAll(), x => x.Name == NEW_NAME);
            Assert.Equal(MyResultsStatus.Ok, results.Status);
            Assert.Equal(MyResultsAction.Updating, results.Action);
        }

        [Fact]
        public void TestExpensesAppService_UpdateExpense_ErroNotFindDomain()
        {
            // arrange
            var dto = _appService.Get(x => x.Id == ID, x => x.Tag).First();
            dto.Id = 1000;
            dto.Name = NEW_NAME;

            // act
            var results = _appService.AddOrUpdate(dto);

            // assert
            Assert.Equal(MyResultsStatus.Error, results.Status);
            Assert.Equal(results.Action, MyResultsAction.Updating);
        }

        [Fact]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            // arrange
            var dto = _appService.GetById(ID, x => x.Tag);

            // act
            var results = _appService.Remove(dto);

            // assert
            Assert.Equal(results.Status, MyResultsStatus.Ok);
            Assert.Equal(results.Action, MyResultsAction.Removing);
        }

        [Fact]
        public void TestExpensesAppService_RemoveExpense_ErrorDomainNotFind()
        {
            // arrange
            var dto = new ExpenseDto { Id = 100 };

            // act
            var results = _appService.Remove(dto);

            // assert
            Assert.Equal(results.Status, MyResultsStatus.Error);
            Assert.Equal(results.Action, MyResultsAction.Removing);
        }

        [Fact]
        public void TestExpensesAppService_RemoveExpense_ErrorNull()
        {
            // act
            var results = _appService.Remove(default(ExpenseDto));

            // assert
            Assert.Equal(results.Status, MyResultsStatus.Error);
            Assert.Equal(results.Action, MyResultsAction.Removing);
        }
    }
}
