/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Repositories
{
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
        private const string NAME1 = "Name1";
        private const string NAME2 = "Name2";

        private ITagsRepository _repository;

        [SetUp]
        public void Setup()
        {
            ICollection<Tag> tags = new List<Tag> { new Tag { Id = ID, Name = NAME1 } };

            ICollection<Expense> expenses = new List<Expense>();

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
            obj.Name = NAME2;

            var result = _repository.AddOrUpdate(obj);

            Assert.AreEqual(result.Status, MyResultsStatus.Ok);
            Assert.AreEqual(result.Action, MyResultsAction.Creating);
            Assert.True(_repository.Get(x => x.Name == NAME2).Any());
        }

        [Test]
        public void TestTagsRepository_Update_Ok()
        {
            var obj = _repository.GetById(ID);
            obj.Name = NAME2;

            var result = _repository.AddOrUpdate(obj);

            Assert.AreEqual(result.Status, MyResultsStatus.Ok);
            Assert.AreEqual(result.Action, MyResultsAction.Updating);
            Assert.True(_repository.Get(x => x.Id == ID && x.Name == NAME2).Any());
        }

        [Test]
        public void TestTagsRepository_AddOrUpdate_ErrorValidation()
        {
            var obj = _repository.GetById(ID);
            obj.Id = -1;

            MyResults result = _repository.AddOrUpdate(obj);

            Assert.AreEqual(result.Status, MyResultsStatus.Error);
            Assert.AreEqual(result.Action, MyResultsAction.Validating);
        }

        [Test]
        public void TestTagsRepository_Remove_Ok()
        {
            var obj = _repository.GetById(ID);

            MyResults result = _repository.Remove(obj);

            Assert.AreEqual(result.Status, MyResultsStatus.Ok);
            Assert.AreEqual(result.Action, MyResultsAction.Removing);
            Assert.False(_repository.Get(x => x.Id == ID).Any());
        }

        [Test]
        public void TestTagsRepository_Remove_IdNotExist()
        {
            var obj = new Tag { Id = 100 };

            MyResults result = _repository.Remove(obj);

            Assert.AreEqual(result.Status, MyResultsStatus.Error);
            Assert.AreEqual(result.Action, MyResultsAction.Removing);
        }
    }
}
