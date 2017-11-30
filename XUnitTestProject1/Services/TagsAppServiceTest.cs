/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Services
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    //using NUnit.Framework;
    using System;
    using System.Linq;

    using MyExpenses.Application.Modules;
    using MyExpenses.Infrastructure.Modules;

    //[TestFixture]
    public class TagsAppServiceTest
    {
        private const string NAME = "Tag1";
        private const string NEW_NAME = "NewName";
        private const long ID = 1;

        private static readonly TagDto[] _invalidDtos =
        {
            // invalid id
            new TagDto { Id = -1, Name = NAME },
            // invalid name
            new TagDto { Id = 1, Name = string.Empty },
            new TagDto { Id = 1, Name = new string ('a', 129) },
            // invalid id, name and value
            new TagDto { Id = -5, Name = null },
            // default
            new TagDto(),
            // null
            null
        };

        private readonly TagDto _validDto = new TagDto { Id = 10, Name = "tmp" };

        private ITagsAppService _appService;

        //[SetUp]
        //public void SetUp()
        //{
        //    MyKernelService.Reset();
        //    MyInfrastructureModule.Init();
        //    MyApplicationModule.Init();
        //    MyKernelService.AddModule(new MyApplicationModuleMock());

        //    _appService = MyKernelService.GetInstance<ITagsAppService>();
        //}

        //[Test]
        //public void TestTagsAppService_GetAllExpenses()
        //{
        //    // arrange

        //    // act
        //    var dtos = _appService.GetAll();

        //    // assert
        //    Assert.True(dtos.Any());
        //}

        //[Test]
        //public void TestTagsAppService_AddOrUpdate_ValidationError([ValueSource(nameof(_invalidDtos))] TagDto dto)
        //{
        //    // arrange

        //    // act
        //    var result = _appService.AddOrUpdate(dto);

        //    // assert
        //    Assert.AreEqual(result.Status, MyResultsStatus.Error);
        //    Assert.AreEqual(result.Action, MyResultsAction.Validating);
        //}

        //[Test]
        //public void TestTagsAppService_GetById_OK()
        //{
        //    // arrange

        //    // act
        //    var dto = _appService.GetById(ID);

        //    // assert
        //    Assert.IsNotNull(dto);
        //    Assert.AreEqual(dto.Name, NAME);
        //}

        //[Test]
        //public void TestTagsAppService_GetById_ErrorNotFind()
        //{
        //    // arrange

        //    // act
        //    var dto = _appService.GetById(1000);

        //    // assert
        //    Assert.IsNull(dto);
        //}

        //[Test]
        //public void TestTagsAppService_AddExpense_OK()
        //{
        //    // arrange
        //    var dto = _validDto;
        //    dto.Id = 0;
        //    dto.Name = NEW_NAME;

        //    // act
        //    var results = _appService.AddOrUpdate(dto);

        //    // assert
        //    Assert.True(_appService.GetAll().Any(x => x.Name == NEW_NAME));
        //    Assert.AreEqual(results.Status, MyResultsStatus.Ok);
        //    Assert.AreEqual(results.Action, MyResultsAction.Creating);
        //}

        //[Test]
        //public void TestTagsAppService_RemoveExpense_OK()
        //{
        //    // arrange
        //    var dto = _appService.GetById(ID);

        //    // act
        //    var results = _appService.Remove(dto);

        //    // assert
        //    Assert.AreEqual(results.Status, MyResultsStatus.Ok);
        //    Assert.AreEqual(results.Action, MyResultsAction.Removing);
        //}

        //[Test]
        //public void TestTagsAppService_RemoveExpense_Error()
        //{
        //    // arrange
        //    var dto = new TagDto { Id = 100 };

        //    // act
        //    var results = _appService.Remove(dto);

        //    // assert
        //    Assert.AreEqual(results.Status, MyResultsStatus.Error);
        //    Assert.AreEqual(results.Action, MyResultsAction.Removing);
        //}
    }
}
