/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.Tests.Context;
    using MyExpenses.Util.Results;
    using NUnit.Framework;

    [TestFixture]
    public class ExpensesRepositoryTest
    {
        private const long EXPENSE_ID = 1;
        private const long TAG_ID = 1;
        private const string TAG_NAME = "Tag1";
        private const string EXPENSE_NAME1 = "Expense1";
        private const string EXPENSE_NAME2 = "Expense2";

        private IExpensesRepository _repository;

        [SetUp]
        public void Setup()
        {
            ICollection<Tag> tags = new List<Tag> { new Tag { Id = TAG_ID, Name = TAG_NAME } };

            ICollection<Expense> expenses = new List<Expense>
            {
                new Expense
                    {
                        Id = EXPENSE_ID,
                        Name = EXPENSE_NAME1,
                        Value = 2,
                        Date = new DateTime(),
                        Tags = tags
                    }
            };

            IMyContext contextMock = new MyContextMock(expenses, tags);

            _repository = new ExpensesRepository(contextMock);
        }

        [TearDown]
        public void TearDown()
        {
            _repository = null;
        }

        [Test]
        public void TestExpensesRepository_GetAll()
        {
            var objs = _repository.GetAll(x => x.Tags).ToList();

            Assert.True(objs.Any());
            Assert.AreEqual(objs[0].Id, EXPENSE_ID);
            Assert.True(objs[0].Tags.Any());
        }

        [Test]
        public void TestExpensesRepository_Add_Ok()
        {
            var obj = _repository.GetById(EXPENSE_ID);
            obj.Id = 0;
            obj.Name = "NewName";

            var result = _repository.AddOrUpdate(obj);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(result.Action == MyResultsAction.Creating);
            Assert.True(_repository.Get(x => x.Name == "NewName", x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepository_Update_Ok()
        {
            var obj = _repository.GetById(EXPENSE_ID);
            obj.Name = EXPENSE_NAME2;

            var result = _repository.AddOrUpdate(obj);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(result.Action == MyResultsAction.Updating);
            Assert.True(_repository.Get(x => x.Id == EXPENSE_ID && x.Name == EXPENSE_NAME2, x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepository_AddOrUpdate_ErrorValidation()
        {
            var obj = _repository.GetById(EXPENSE_ID);
            obj.Id = -1;

            MyResults result = _repository.AddOrUpdate(obj);

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(result.Action == MyResultsAction.Validating);
        }

        [Test]
        public void TestExpensesRepository_Remove_Ok()
        {
            var obj = _repository.GetById(EXPENSE_ID);

            MyResults result = _repository.Remove(obj);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(result.Action == MyResultsAction.Removing);
            Assert.False(_repository.Get(x => x.Id == EXPENSE_ID, x => x.Tags).Any());
        }

        [Test]
        public void TestExpensesRepository_Remove_IdNotExist()
        {
            var obj = new Expense { Id = 100 };
         
            MyResults result = _repository.Remove(obj);

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(result.Action == MyResultsAction.Removing);
        }
    }
}
