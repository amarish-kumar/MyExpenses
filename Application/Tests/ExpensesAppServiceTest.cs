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
    using System.Linq.Expressions;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private Mock<IExpensesService> _expensesServiceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private List<Expense> _expenses = new List<Expense>
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
        }

        [Test]
        public void DummyTestWhenIsTrue()
        {
            Assert.True(true);
        }
    }
}
