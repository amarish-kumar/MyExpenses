/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Services
{
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Services;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class TagsServiceTest
    {
        private const long ID1 = 1;
        private const long ID2 = 2;
        private const string NEWNAME = "NewName";

        private ITagsService _service;

        [SetUp]
        public void Setup()
        {
            MyKernelService.Reset();
            MyKernelService.AddModule(new MyDomainModuleMock());

            _service = MyKernelService.GetInstance<TagsService>();
        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
        }

        [Test]
        public void TestTagsServiceSaveAndUpdate()
        {
            var obj = _service.GetById(1);
            obj.Name = NEWNAME;

            MyResults results = _service.AddOrUpdate(obj);

            Assert.True(results.Type == MyResultsType.Ok);
            obj = _service.GetById(ID1);
            Assert.AreEqual(obj.Name, NEWNAME);
        }

        [Test]
        public void TestTagsServiceGet()
        {
            var obj = _service.Get(x => x.Id == ID1).First();

            Assert.True(obj.Equals(_service.GetById(ID1)));
        }

        [Test]
        public void TestTagsServiceGetAll()
        {
            var objs = _service.GetAll();

            Assert.True(objs.Any());
        }

        [Test]
        public void TestTagsServiceRemove()
        {
            var obj = _service.GetById(ID2);

            MyResults results = _service.Remove(obj);

            Assert.True(results.Type == MyResultsType.Ok);
            Assert.IsNull(_service.GetById(ID2));
        }
    }
}
