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

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;
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

        private Mock<IMyContext> _contextMock;

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

            Mock<DbSet<Expense>> moq = Util.GetMockSet(expensesOb);

            _contextMock = new Mock<IMyContext>(MockBehavior.Strict);
            _contextMock.Setup(x => x.Set<Expense>()).Returns(moq.Object);
            _contextMock.Setup(x => x.SaveChanges()).Returns(0);
        }

        [TearDown]
        public void TearDown()
        {
            _contextMock = null;
        }

        [Test]
        public void TestExpensesRepoGetAll()
        {
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            List<Expense> expenses = expenseRepo.GetAll(x => x.Tags).ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses[0].Id == EXPENSE_ID);
            Assert.True(expenses[0].Tags.Any());
        }

        [Test]
        public void TestExpensesRepoGet()
        {
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            List<Expense> expenses = expenseRepo.Get(x => x.Id == EXPENSE_ID, x => x.Tags).ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses.FirstOrDefault()?.Id == EXPENSE_ID);
        }

        [Test]
        public void TestExpensesRepoGetById()
        {
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            Expense expense = expenseRepo.GetById(EXPENSE_ID, x => x.Tags);

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
            IUnitOfWork unitOfWork = new UnitOfWork(_contextMock.Object);
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            unitOfWork.BeginTransaction();
            MyResults result = expenseRepo.SaveOrUpdate(expense);
            unitOfWork.Commit();

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(expenseRepo.Get(x => x.Id == EXPENSE_ID, x => x.Tags).Any());
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
            IUnitOfWork unitOfWork = new UnitOfWork(_contextMock.Object);
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            unitOfWork.BeginTransaction();
            expenseRepo.SaveOrUpdate(expense);
            unitOfWork.Commit();

            Assert.True(expenseRepo.Get(x => x.Id == EXPENSE_ID && x.Name == EXPENSE_NAME2, x => x.Tags).Any());
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
            IUnitOfWork unitOfWork = new UnitOfWork(_contextMock.Object);
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            unitOfWork.BeginTransaction();
            MyResults result = expenseRepo.SaveOrUpdate(expense);
            unitOfWork.Commit();

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(expenseRepo.Get(x => x.Id == 1, x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepoUpdateWhenUnitOfWorkException()
        {
            Expense expense = new Expense
            {
                Id = EXPENSE_ID,
                Name = EXPENSE_NAME1,
                Value = 2,
                Date = new DateTime(),
                Tags = new List<Tag>()
            };

            IUnitOfWork unitOfWork = new UnitOfWork(null);
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            unitOfWork.BeginTransaction();
            expenseRepo.SaveOrUpdate(expense);
            Assert.Throws<Exception>(() => unitOfWork.Commit());
        }

        [Test]
        public void TestExpensesRepoRemoveOk()
        {
            Expense expense = new Expense
            {
                Id = EXPENSE_ID
            };
            IUnitOfWork unitOfWork = new UnitOfWork(_contextMock.Object);
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            unitOfWork.BeginTransaction();
            MyResults result = expenseRepo.Remove(expense);
            unitOfWork.Commit();

            List<Expense> expenses = expenseRepo.Get(x => x.Id == EXPENSE_ID, x => x.Tags).ToList();
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
            IUnitOfWork unitOfWork = new UnitOfWork(_contextMock.Object);
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            unitOfWork.BeginTransaction();
            MyResults result = expenseRepo.Remove(expense);
            unitOfWork.Commit();

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(expenseRepo.GetAll(x => x.Tags).Any());
        }
    }
}
