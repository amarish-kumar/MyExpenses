/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests
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
    public class TagsRepoTest
    {
        const long TAG_ID = 1;
        private Mock<IMyContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            ObservableCollection<Tag> expensesOb =
                new ObservableCollection<Tag>
                    {
                        new Tag
                            {
                                Id = TAG_ID,
                                Name = "Tag1",
                                Expenses = new List<Expense>()
                            }
                    };

            Mock<DbSet<Tag>> moq = MyExpensesUtil.GetMockSet(expensesOb);

            _contextMock = new Mock<IMyContext>(MockBehavior.Strict);
            _contextMock.Setup(x => x.Set<Tag>()).Returns(moq.Object);
            _contextMock.Setup(x => x.SaveChanges()).Returns(0);
        }

        [TearDown]
        public void TearDown()
        {
            _contextMock = null;
        }

        [Test]
        public void TestTagRepoGetAll()
        {
            ITagsRepo tagsRepo = new TagsRepo(_contextMock.Object);

            List<Tag> expenses = tagsRepo.GetAll(x => x.Expenses).ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses.FirstOrDefault()?.Id == TAG_ID);
        }

        [Test]
        public void TestExpensesRepoGet()
        {
            ITagsRepo tagsRepo = new TagsRepo(_contextMock.Object);

            List<Tag> tags = tagsRepo.Get(x => x.Id == TAG_ID, x => x.Expenses).ToList();

            Assert.True(tags.Any());
            Assert.True(tags.FirstOrDefault()?.Id == TAG_ID);
        }
    }
}
