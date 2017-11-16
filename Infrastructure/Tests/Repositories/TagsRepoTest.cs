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
    using NUnit.Framework;

    [TestFixture]
    public class TagsRepoTest
    {
        private const long EXPENSE_ID = 1;
        private const long TAG_ID = 1;
        private const string TAG_NAME = "Tag1";
        private const string EXPENSE_NAME = "Expense";

        private ITagsRepository _repository;

        [SetUp]
        public void Setup()
        {
            ICollection<Tag> tags = new List<Tag> { new Tag { Id = TAG_ID, Name = TAG_NAME } };

            ICollection<Expense> expenses = new List<Expense>
            {
                new Expense
                    {
                        Id = EXPENSE_ID,
                        Name = EXPENSE_NAME,
                        Value = 2,
                        Date = new DateTime(),
                        Tags = tags
                    }
            };

            IMyContext contextMock = new MyContextMock(expenses, tags);
            _repository = new TagsRepository(contextMock);
        }

        [TearDown]
        public void TearDown()
        {
            _repository = null;
        }

        [Test]
        public void TestTagRepoGetAll()
        {
            List<Tag> expenses = _repository.GetAll().ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses.FirstOrDefault()?.Id == TAG_ID);
        }

        [Test]
        public void TestExpensesRepoGet()
        {
            List<Tag> tags = _repository.Get(x => x.Id == TAG_ID).ToList();

            Assert.True(tags.Any());
            Assert.True(tags.FirstOrDefault()?.Id == TAG_ID);
        }
    }
}
