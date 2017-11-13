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
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    using NUnit.Framework;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private const string NAME = "Expense1";
        private const long ID = 1;

        private Mock<IExpensesService> _serviceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ExpensesAdapter _adapter;

        private readonly List<Expense> _expenses = new List<Expense>
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

        [SetUp]
        public void SetUp()
        {
            _adapter = new ExpensesAdapter(new TagsAdapter());
            _serviceMock = new Mock<IExpensesService>(MockBehavior.Strict);
            
            _serviceMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Expense, object>>[]>())).Returns(_expenses);
            _serviceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok, ""));
            _serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok, ""));
            _serviceMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(_expenses.FirstOrDefault());

            _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _unitOfWorkMock.Setup(x => x.BeginTransaction());
            _unitOfWorkMock.Setup(x => x.Commit());
        }

        [Test]
        public void TestExpensesAppService_GetAllExpenses()
        {
            var appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);

            var dtos = appService.GetAll();
            
            Assert.True(_expenses.Count == dtos.Count);
        }

        [Test]
        public void TestExpensesAppService_GetById_OK()
        {
            var appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);

            var dto = appService.GetById(ID);

            Assert.IsNotNull(dto);
            Assert.IsTrue(dto.Name.Equals(NAME));
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_OK()
        {
            var appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            var dto = _adapter.ToDto(_expenses.FirstOrDefault());

            var results = appService.SaveOrUpdate(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_Error()
        {
            _serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Error, ""));

            var appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            var dto = _adapter.ToDto(_expenses.FirstOrDefault());

            var results = appService.SaveOrUpdate(dto);

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            var appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            var dto = _adapter.ToDto(_expenses.FirstOrDefault());

            var results = appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_Error()
        {
            _serviceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Error, ""));

            var appService = new ExpensesAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            var dto = _adapter.ToDto(_expenses.FirstOrDefault());

            var results = appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
