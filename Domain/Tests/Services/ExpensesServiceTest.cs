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

    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Services;
    using MyExpenses.Domain.Tests.Mocks;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Tests.Context;
    using MyExpenses.Util.Results;

    using NUnit.Framework;

    [TestFixture]
    public class ExpensesServiceTest
    {
        private IExpensesService _service;

        [SetUp]
        public void Setup()
        {
            ICollection<Tag> tags = new List<Tag> { new Tag { Id = 1, Name = "a" } };
            List<Expense> expenses = new List<Expense>
                                          {
                                              new Expense
                                                  {
                                                      Id = 1,
                                                      Name = "Expense1",
                                                      Date = new DateTime(),
                                                      Value = 2
                                                  }
                                          };

            IMyContext contextMock = new MyContextMock(expenses, tags);

            IExpensesRepository expensesRepo = new ExpensesRepositoryMock(contextMock);
            ITagsRepository tagsRepo = new TagsRepositoryMock(contextMock);

            _service = new ExpensesService(expensesRepo, tagsRepo);
        }

        // TODO #61 Use ninject in unit-tests 

        [Test]
        public void TestExpensesServiceGet()
        {
            List<Expense> expenses = _service.Get(x => x.Id == 1).ToList();

            Assert.True(expenses.Any());
        }

        [Test]
        public void TestExpensesServiceGetAll()
        {
            List<Expense> expenses = _service.GetAll().ToList();

            Assert.True(expenses.Any());
        }

        [Test]
        public void TestExpensesServiceGetById()
        {
            Expense expense = _service.GetById(1);

            Assert.IsNotNull(expense);
            Assert.True(expense.Name == "Expense1");
        }

        [Test]
        public void TestExpensesServiceRemove()
        {
            Expense expense = _service.GetById(1);
            MyResults results = _service.Remove(expense);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpensesServiceSaveAndUpdate()
        {
            Expense expense = _service.GetById(1);
            expense.Name = "NewExpense";

            MyResults results = _service.AddOrUpdate(expense);

            Assert.True(results.Type == MyResultsType.Ok);

            Expense newExpense = _service.GetById(1);
            Assert.True(newExpense.Name == "NewExpense");
        }
    }
}
