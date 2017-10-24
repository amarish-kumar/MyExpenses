/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests
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
    using NUnit.Framework;
    using MyExpenses.Util.Results;

    [TestFixture]
    public class TagsServiceTest
    {
        private Mock<ITagsRepo> _tagsRepoMock;

        private List<Tag> _tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "Tag1",
                }
            };

        [SetUp]
        public void Setup()
        {
            _tagsRepoMock = new Mock<ITagsRepo>(MockBehavior.Strict);

            
            _tagsRepoMock.Setup(x => x.GetAll()).Returns(_tags);
            _tagsRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Tag, bool>>>())).Returns(_tags);
            _tagsRepoMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(_tags.FirstOrDefault());
            _tagsRepoMock.Setup(x => x.Remove(It.IsAny<Tag>())).Returns(new MyResults(MyResultsType.Ok, ""));
            _tagsRepoMock.Setup(x => x.SaveOrUpdate(It.IsAny<Tag>())).Returns(new MyResults(MyResultsType.Ok, ""));
        }

        [Test]
        public void TestTagsServiceGet()
        {
            ITagsService tagsService = new TagsService(_tagsRepoMock.Object);

            var tags = tagsService.Get(x => x.Id == 1);

            Assert.True(tags.Any());
        }

        [Test]
        public void TestTagsServiceGetAll()
        {
            ITagsService tagsService = new TagsService(_tagsRepoMock.Object);

            var tags = tagsService.GetAll();

            Assert.True(tags.Any());
        }

        [Test]
        public void TestTagsServiceGetById()
        {
            ITagsService tagsService = new TagsService(_tagsRepoMock.Object);

            var expense = tagsService.GetById(1);

            Assert.IsNotNull(expense);
            Assert.True(expense.Equals(_tags.FirstOrDefault()));
        }

        [Test]
        public void TestTagsServiceRemove()
        {
            ITagsService tagsService = new TagsService(_tagsRepoMock.Object);

            MyResults results = tagsService.Remove(_tags.FirstOrDefault());

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestTagsServiceSaveAndUpdate()
        {
            ITagsService tagsService = new TagsService(_tagsRepoMock.Object);

            MyResults results = tagsService.SaveOrUpdate(_tags.FirstOrDefault());

            Assert.True(results.Type == MyResultsType.Ok);
        }
    }
}
