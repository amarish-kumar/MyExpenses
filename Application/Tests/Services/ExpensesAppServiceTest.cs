/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests
{
    using Moq;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Services;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private Mock<IExpensesService> _expensesServiceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private readonly List<Expense> _expenses = new List<Expense>
            {
                new Expense
                {
                    Id = 1,
                    Name = "Expense1",
                    Date = new DateTime(),
                    Value = 2
                }
            };

        [SetUp]
        public void SetUp()
        {
            _expensesServiceMock = new Mock<IExpensesService>(MockBehavior.Strict);
            
            _expensesServiceMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Expense, object>>[]>())).Returns(_expenses);
            _expensesServiceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok, ""));
            _expensesServiceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok, ""));

            _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _unitOfWorkMock.Setup(x => x.BeginTransaction());
            _unitOfWorkMock.Setup(x => x.Commit());
        }

        [Test]
        public void TestExpensesAppService_GetAllExpenses()
        {
            ExpensesAppService expensesAppService = new ExpensesAppService(_expensesServiceMock.Object, _unitOfWorkMock.Object);

            List<ExpenseDto> expenses = expensesAppService.GetAllExpenses();
            
            Assert.True(_expenses.Count == expenses.Count);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_OK()
        {
            ExpensesAppService expensesAppService = new ExpensesAppService(_expensesServiceMock.Object, _unitOfWorkMock.Object);
            ExpenseDto expenseDto = new ExpenseDto(_expenses.FirstOrDefault());

            MyResults results = expensesAppService.SaveOrUpdateExpense(expenseDto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_Error()
        {
            _expensesServiceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Error, ""));

            ExpensesAppService expensesAppService = new ExpensesAppService(_expensesServiceMock.Object, _unitOfWorkMock.Object);
            ExpenseDto expenseDto = new ExpenseDto(_expenses.FirstOrDefault());

            MyResults results = expensesAppService.SaveOrUpdateExpense(expenseDto);

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            ExpensesAppService expensesAppService = new ExpensesAppService(_expensesServiceMock.Object, _unitOfWorkMock.Object);
            ExpenseDto expenseDto = new ExpenseDto(_expenses.FirstOrDefault());

            MyResults results = expensesAppService.RemoveExpense(expenseDto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_Error()
        {
            _expensesServiceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Error, ""));

            ExpensesAppService expensesAppService = new ExpensesAppService(_expensesServiceMock.Object, _unitOfWorkMock.Object);
            ExpenseDto expenseDto = new ExpenseDto(_expenses.FirstOrDefault());

            MyResults results = expensesAppService.RemoveExpense(expenseDto);

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
