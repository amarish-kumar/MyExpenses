/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Moq;

    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Services;
    using MyExpenses.Util.Results;

    using NUnit.Framework;

    [TestFixture]
    public class ExpensesServiceTest
    {
        private Mock<IExpensesRepository> _expensesRepoMock;

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
        public void Setup()
        {
            _expensesRepoMock = new Mock<IExpensesRepository>(MockBehavior.Strict);

            _expensesRepoMock.Setup(x => x.GetAll()).Returns(_expenses);
            _expensesRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Expense, bool>>>())).Returns(_expenses);
            _expensesRepoMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(_expenses.FirstOrDefault());
            _expensesRepoMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok));
            _expensesRepoMock.Setup(x => x.AddOrUpdate(It.IsAny<Expense>())).Returns(new MyResults(MyResultsType.Ok));
        }

        // TODO #61 Use ninject in unit-tests 

        //[Test]
        //public void TestExpensesServiceGet()
        //{
        //    IExpensesService expensesService = new ExpensesService(_expensesRepoMock.Object);

        //    List<Expense> expenses = expensesService.Get(x => x.Id == 1).ToList();

        //    Assert.True(expenses.Any());
        //}

        //[Test]
        //public void TestExpensesServiceGetAll()
        //{
        //    IExpensesService expensesService = new ExpensesService(_expensesRepoMock.Object);

        //    List<Expense> expenses = expensesService.GetAll().ToList();

        //    Assert.True(expenses.Any());
        //}

        //[Test]
        //public void TestExpensesServiceGetById()
        //{
        //    IExpensesService expensesService = new ExpensesService(_expensesRepoMock.Object);

        //    Expense expense = expensesService.GetById(1);

        //    Assert.IsNotNull(expense);
        //    Assert.True(expense.Equals(_expenses.FirstOrDefault()));
        //}

        //[Test]
        //public void TestExpensesServiceRemove()
        //{
        //    IExpensesService expensesService = new ExpensesService(_expensesRepoMock.Object);

        //    MyResults results = expensesService.Remove(_expenses.FirstOrDefault());

        //    Assert.True(results.Type == MyResultsType.Ok);
        //}

        //[Test]
        //public void TestExpensesServiceSaveAndUpdate()
        //{
        //    IExpensesService expensesService = new ExpensesService(_expensesRepoMock.Object);

        //    MyResults results = expensesService.AddOrUpdate(_expenses.FirstOrDefault());

        //    Assert.True(results.Type == MyResultsType.Ok);
        //}
    }
}
