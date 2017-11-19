/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Services
{
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Services;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class TagsServiceTest
    {
        private ITagsService _service;

        [SetUp]
        public void Setup()
        {
            MyKernelService.Init();
            MyKernelService.AddModule(new MyDomainModuleMock());

            _service = MyKernelService.GetInstance<TagsService>();
        }

        [Test]
        public void TestTagsServiceSaveAndUpdate()
        {
            var obj = _service.GetById(1);
            obj.Name = "NewName";

            MyResults results = _service.AddOrUpdate(obj);

            Assert.True(results.Type == MyResultsType.Ok);
            obj = _service.GetById(1);
            Assert.True(obj.Name == "NewName");
        }

        [Test]
        public void TestTagsServiceGet()
        {
            var obj = _service.Get(x => x.Id == 1).First();

            Assert.True(obj.Equals(_service.GetById(1)));
        }

        [Test]
        public void TestTagsServiceGetAll()
        {
            var objs = _service.GetAll().ToList();

            Assert.True(objs.Any());
        }

        [Test]
        public void TestTagsServiceRemove()
        {
            var obj = _service.GetById(2);

            MyResults results = _service.Remove(obj);

            Assert.True(results.Type == MyResultsType.Ok);
            Assert.IsNull(_service.GetById(2));
        }
    }
}
