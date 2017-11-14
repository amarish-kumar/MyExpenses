/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;

    using Moq;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Util.Results;

    using NUnit.Framework;

    [TestFixture]
    public class ExpensesRepoTest
    {
        private const long EXPENSE_ID = 1;
        private const long TAG_ID = 1;
        private const string TAG_NAME = "Tag1";
        private const string EXPENSE_NAME1 = "Expense1";
        private const string EXPENSE_NAME2 = "Expense2";

        private IExpensesRepo _repository;

        [SetUp]
        public void Setup()
        {
            ObservableCollection<Expense> expensesOb =
                new ObservableCollection<Expense>
                    {
                        new Expense
                            {
                                Id = EXPENSE_ID,
                                Name = EXPENSE_NAME1,
                                Value = 2,
                                Date = new DateTime(),
                                Tags = new List<Tag>
                                           {
                                               new Tag
                                                   {
                                                       Id = TAG_ID,
                                                       Name = TAG_NAME
                                                   }
                                           }
                            }
                    };

            Mock<DbSet<Expense>> moq = DbSetMock.GetMock(expensesOb);

            Mock<IMyContext> contextMock = new Mock<IMyContext>(MockBehavior.Strict);
            contextMock.Setup(x => x.Set<Expense>()).Returns(moq.Object);
            contextMock.Setup(x => x.SaveChanges()).Returns(0);

            _repository = new ExpensesRepo(contextMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _repository = null;
        }

        [Test]
        public void TestExpensesRepoGetAll()
        {
            List<Expense> expenses = _repository.GetAll(x => x.Tags).ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses[0].Id == EXPENSE_ID);
            Assert.True(expenses[0].Tags.Any());
        }

        [Test]
        public void TestExpensesRepoGet()
        {
            List<Expense> expenses = _repository.Get(x => x.Id == EXPENSE_ID, x => x.Tags).ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses.FirstOrDefault()?.Id == EXPENSE_ID);
        }

        [Test]
        public void TestExpensesRepoGetById()
        {
            Expense expense = _repository.GetById(EXPENSE_ID, x => x.Tags);

            Assert.IsNotNull(expense);
            Assert.True(expense.Id == EXPENSE_ID);
        }

        [Test]
        public void TestExpensesRepoAddOk()
        {
            Expense expense = new Expense
            {
                Id = EXPENSE_ID + 1,
                Name = EXPENSE_NAME1,
                Value = 2,
                Date = new DateTime(),
                Tags = new List<Tag>()
            };

            MyResults result = _repository.AddOrUpdate(expense);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(_repository.Get(x => x.Id == EXPENSE_ID, x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepoUpdateOk()
        {
            Expense expense = new Expense
            {
                Id = EXPENSE_ID,
                Name = EXPENSE_NAME2,
                Value = 2,
                Date = new DateTime(),
                Tags = new List<Tag>()
            };

            _repository.AddOrUpdate(expense);

            Assert.True(_repository.Get(x => x.Id == EXPENSE_ID && x.Name == EXPENSE_NAME2, x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepoUpdateWhenInvalidId()
        {
            Expense expense = new Expense
            {
                Id = -1,
                Name = EXPENSE_NAME1,
                Value = 2,
                Date = new DateTime(),
                Tags = new List<Tag>()
            };

            MyResults result = _repository.AddOrUpdate(expense);

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(_repository.Get(x => x.Id == 1, x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepoRemoveOk()
        {
            Expense expense = new Expense
            {
                Id = EXPENSE_ID
            };

            MyResults result = _repository.Remove(expense);

            List<Expense> expenses = _repository.Get(x => x.Id == EXPENSE_ID, x => x.Tags).ToList();
            Assert.True(result.Type == MyResultsType.Ok);
            Assert.False(expenses.Any());
        }

        [Test]
        public void TestExpensesRepoRemoveWhenIdNotExist()
        {
            Expense expense = new Expense
            {
                Id = EXPENSE_ID + 1
            };

            MyResults result = _repository.Remove(expense);

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(_repository.GetAll(x => x.Tags).Any());
        }
    }
}
