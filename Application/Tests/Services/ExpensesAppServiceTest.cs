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
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    using NUnit.Framework;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private Mock<IExpensesService> _serviceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ExpensesAdapter _adapter;

        private readonly List<Expense> _expenses = new List<Expense>
            {
                new Expense
                {
                    Id = 1,
                    Name = "Expense1",
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

        [SetUp]
        public void SetUp()
        {
            _adapter = new ExpensesAdapter(new TagsAdapter());
            _serviceMock = new Mock<IExpensesService>(MockBehavior.Strict);
            
            _serviceMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Expense, object>>[]>())).Returns(_expenses);
            _serviceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok, ""));
            _serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok, ""));

            _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _unitOfWorkMock.Setup(x => x.BeginTransaction());
            _unitOfWorkMock.Setup(x => x.Commit());
        }

        [Test]
        public void TestExpensesAppService_GetAllExpenses()
        {
            ExpensesAppService appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);

            ICollection<ExpenseDto> dtos = appService.GetAll();
            
            Assert.True(_expenses.Count == dtos.Count);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_OK()
        {
            ExpensesAppService appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            ExpenseDto dto = _adapter.ToDto(_expenses.FirstOrDefault());

            MyResults results = appService.SaveOrUpdate(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_Error()
        {
            _serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Error, ""));

            ExpensesAppService appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            ExpenseDto dto = _adapter.ToDto(_expenses.FirstOrDefault());

            MyResults results = appService.SaveOrUpdate(dto);

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            ExpensesAppService appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            ExpenseDto dto = _adapter.ToDto(_expenses.FirstOrDefault());

            MyResults results = appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_Error()
        {
            _serviceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Error, ""));

            ExpensesAppService appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            ExpenseDto dto = _adapter.ToDto(_expenses.FirstOrDefault());

            MyResults results = appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
