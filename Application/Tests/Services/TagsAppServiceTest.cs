/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Moq;

    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    using NUnit.Framework;

    [TestFixture]
    public class TagsAppServiceTest
    {
        private Mock<ITagsService> _serviceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private TagsAdapter _adapter;

        private readonly List<Tag> _tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "Tag1"
                }
            };

        [SetUp]
        public void SetUp()
        {
            _adapter = new TagsAdapter();
            _serviceMock = new Mock<ITagsService>(MockBehavior.Strict);
            
            _serviceMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Tag, object>>[]>())).Returns(_tags);
            _serviceMock.Setup(x => x.Remove(It.IsAny<Tag>())).Returns(new MyResults(MyResultsType.Ok, ""));
            _serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Tag>())).Returns(new MyResults(MyResultsType.Ok, ""));

            _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _unitOfWorkMock.Setup(x => x.BeginTransaction());
            _unitOfWorkMock.Setup(x => x.Commit());
        }

        [Test]
        public void TestTagsAppService_GetAllTags()
        {
            TagsAppService appService = new TagsAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);

            ICollection<TagDto> dtos = appService.GetAll();
            
            Assert.True(_tags.Count == dtos.Count);
        }

        [Test]
        public void TestTagsAppService_SaveAndUpdateTag_OK()
        {
            TagsAppService appService = new TagsAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            TagDto dto = _adapter.ToDto(_tags.FirstOrDefault());

            MyResults results = appService.SaveOrUpdate(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestTagsAppService_SaveAndUpdateTag_Error()
        {
            _serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Tag>())).Returns(new MyResults(MyResultsType.Error, ""));

            TagsAppService appService = new TagsAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            TagDto dto = _adapter.ToDto(_tags.FirstOrDefault());

            MyResults results = appService.SaveOrUpdate(dto);

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestTagsAppService_RemoveTag_OK()
        {
            TagsAppService appService = new TagsAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            TagDto dto = _adapter.ToDto(_tags.FirstOrDefault());

            MyResults results = appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestTagsAppService_RemoveTag_Error()
        {
            _serviceMock.Setup(x => x.Remove(It.IsAny<Tag>())).Returns(new MyResults(MyResultsType.Error, ""));

            TagsAppService appService = new TagsAppService(_serviceMock.Object, _unitOfWorkMock.Object, _adapter);
            TagDto dto = _adapter.ToDto(_tags.FirstOrDefault());

            MyResults results = appService.Remove(dto);

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
