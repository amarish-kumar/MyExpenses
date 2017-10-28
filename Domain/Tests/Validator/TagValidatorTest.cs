/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Validator
{
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;
    using NUnit.Framework;

    [TestFixture]
    public class TagValidatorTest
    {
        private Tag _tag;

        [SetUp]
        public void Setup()
        {
            _tag = new Tag
            {
                Id = 1,
                Name = "Tag1"
            };
        }

        [Test]
        public void TestTagValidator_Validate_Ok()
        {
            MyResults results = _tag.Validate();

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestTagValidator_IdIsInvalid_Validate_ResultError()
        {
            _tag.Id = -1;

            MyResults results = _tag.Validate();

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestTagValidator_NameIsEmtpy_Validate_ResultError()
        {
            _tag.Name = string.Empty;

            MyResults results = _tag.Validate();

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
