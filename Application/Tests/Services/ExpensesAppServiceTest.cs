/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Moq;

    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Tests.Modules;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;

    using NUnit.Framework;
    using MyExpenses.Application.Tests.ServiceMock;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private const string NAME = "Expense1";
        private const long ID = 1;

        private readonly IAdapter<Expense, ExpenseDto> _adapter = new ExpensesAdapter(new TagsAdapter());
        private readonly ExpenseDto _invalidDto = new ExpenseDto { Id = 10, Name = string.Empty };
        private readonly ExpenseDto _validDto = new ExpenseDto { Id = 10, Name = "tmp", Value = 1, Date = new DateTime() };

        private IExpensesAppService<ExpenseDto> _appService;

        private static readonly List<Expense> _expenses = new List<Expense>
            {
                new Expense
                {
                    Id = ID,
                    Name = NAME,
                    Date = new DateTime(),
                    Value = 2,
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = 1,
                            Name = "Tag1"
                        }
                    }
                }
            };

        private static readonly List<Tag> _tags = new List<Tag>
            {
                new Tag
                    {
                        Id = ID,
                        Name = NAME
                    },
                new Tag
                    {
                        Id = ID + 1,
                        Name = NAME + 1
                    }
            };

        [SetUp]
        public void SetUp()
        {
            var serviceMock = ExpensesServiceMock.GetMock(_expenses);
            var tagServiceMock = TagsServiceMock.GetMock(_tags);

            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(x => x.BeginTransaction());
            unitOfWorkMock.Setup(x => x.Commit());

            MyKernelService.Init();
            MyKernelService.AddModule(new MyApplicationModuleMock(serviceMock, tagServiceMock, unitOfWorkMock));

            _appService = MyKernelService.GetInstance<IExpensesAppService<ExpenseDto>>();
        }

        [Test]
        public void TestExpensesAppService_GetAllExpenses()
        {
            var dtos = _appService.GetAll();
            
            Assert.True(_expenses.Count == dtos.Count);
        }

        [Test]
        public void TestExpensesAppService_GetById_OK()
        {
            var dto = _appService.GetById(ID);

            Assert.IsNotNull(dto);
            Assert.IsTrue(dto.Name.Equals(NAME));
        }

        [Test]
        public void TestExpensesAppService_SaveExpense_OK()
        {
            int before = _appService.GetAll().Count;
            var results = _appService.SaveOrUpdate(_validDto);
            int after = _appService.GetAll().Count;

            Assert.True(before < after);
            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_Error()
        {
            var results = _appService.SaveOrUpdate(_invalidDto);

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            var dto = _adapter.ToDto(_expenses.FirstOrDefault());

            var results = _appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_Error()
        {
            var results = _appService.Remove(_invalidDto);

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
