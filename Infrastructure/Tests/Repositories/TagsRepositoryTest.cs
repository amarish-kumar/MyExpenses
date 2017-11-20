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
    public class TagsRepositoryTest
    {
        private const long ID = 1;
        private const string NEWNAME = "NewName";

        private ITagsRepository _repository;

        [SetUp]
        public void Setup()
        {
            ICollection<Tag> tags = new List<Tag> { new Tag { Id = ID, Name = "Tag" } };

            ICollection<Expense> expenses = new List<Expense>
            {
                new Expense
                    {
                        Id = 1,
                        Name = "Expense",
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
        public void TestTagsRepository_GetAll()
        {
            var objs = _repository.GetAll().ToList();

            Assert.True(objs.Any());
            Assert.AreEqual(objs[0].Id, ID);
        }

        [Test]
        public void TestTagsRepository_Add_Ok()
        {
            var obj = _repository.GetById(ID);
            obj.Id = 0;
            obj.Name = "NewName";

            var result = _repository.AddOrUpdate(obj);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(result.Action == MyResultsAction.Creating);
            Assert.True(_repository.Get(x => x.Name == "NewName").Any());
        }

        [Test]
        public void TestTagsRepository_Update_Ok()
        {
            var obj = _repository.GetById(ID);
            obj.Name = NEWNAME;

            var result = _repository.AddOrUpdate(obj);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(result.Action == MyResultsAction.Updating);
            Assert.True(_repository.Get(x => x.Id == ID && x.Name == NEWNAME).Any());
        }

        [Test]
        public void TestTagsRepository_AddOrUpdate_ErrorValidation()
        {
            var obj = _repository.GetById(ID);
            obj.Id = -1;

            MyResults result = _repository.AddOrUpdate(obj);

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(result.Action == MyResultsAction.Validating);
        }

        [Test]
        public void TestTagsRepository_Remove_Ok()
        {
            var obj = _repository.GetById(ID);

            MyResults result = _repository.Remove(obj);

            Assert.True(result.Type == MyResultsType.Ok);
            Assert.True(result.Action == MyResultsAction.Removing);
            Assert.False(_repository.Get(x => x.Id == ID).Any());
        }

        [Test]
        public void TestTagsRepository_Remove_IdNotExist()
        {
            var obj = new Tag { Id = 100 };

            MyResults result = _repository.Remove(obj);

            Assert.True(result.Type == MyResultsType.Error);
            Assert.True(result.Action == MyResultsAction.Removing);
        }
    }
}
