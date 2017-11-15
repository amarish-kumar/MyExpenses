/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;

    using Moq;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;

    using NUnit.Framework;

    [TestFixture]
    public class TagsRepoTest
    {
        private const long TAG_ID = 1;
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
                                Name = "Tag1"
                            }
                    };

            Mock<DbSet<Tag>> moq = DbSetMock.GetMock(expensesOb);

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
            // TODO #61 fix referece using ninject
            ITagsRepository tagsRepo = new TagsRepository(_contextMock.Object);

            List<Tag> expenses = tagsRepo.GetAll().ToList();

            Assert.True(expenses.Any());
            Assert.True(expenses.FirstOrDefault()?.Id == TAG_ID);
        }

        [Test]
        public void TestExpensesRepoGet()
        {
            // TODO #61 fix referece using ninject
            ITagsRepository tagsRepo = new TagsRepository(_contextMock.Object);

            List<Tag> tags = tagsRepo.Get(x => x.Id == TAG_ID).ToList();

            Assert.True(tags.Any());
            Assert.True(tags.FirstOrDefault()?.Id == TAG_ID);
        }
    }
}
