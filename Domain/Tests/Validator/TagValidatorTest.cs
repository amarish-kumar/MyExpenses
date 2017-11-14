/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Validator
{
    using System;

    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Validator;
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
        public static void TestTagValidator_Invalid()
        {
            TagValidator tagValidator = new TagValidator();
            Assert.Throws<ArgumentException>(() => tagValidator.Validate(null));
            Assert.Throws<ArgumentException>(() => tagValidator.Validate(new Expense()));
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

        [Test]
        public void TestTagValidator_NameIsTooBig_Validate_ResultError()
        {
            _tag.Name = string.Empty;
            for (int i = 0; i < 129; i++)
            {
                _tag.Name += "a";
            }

            MyResults results = _tag.Validate();

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
