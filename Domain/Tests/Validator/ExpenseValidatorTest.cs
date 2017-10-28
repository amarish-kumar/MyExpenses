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
    public class ExpenseValidatorTest
    {
        private Expense _expense;

        [SetUp]
        public void Setup()
        {
            _expense = new Expense
            {
                Id = 1,
                Name = "Expense1",
                Value = 1,
                Date = new System.DateTime()
            };
        }

        [Test]
        public void TestExpenseValidator_Validate_Ok()
        {
            MyResults results = _expense.Validate();

            Assert.True(results.Type == MyResultsType.Ok);
        }

        [Test]
        public void TestExpenseValidator_IdIsInvalid_Validate_ResultError()
        {
            _expense.Id = -1;

            MyResults results = _expense.Validate();

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestExpenseValidator_NameIsEmtpy_Validate_ResultError()
        {
            _expense.Name = string.Empty;

            MyResults results = _expense.Validate();

            Assert.True(results.Type == MyResultsType.Error);
        }

        [Test]
        public void TestExpenseValidator_InvalidValue_Validate_ResultError()
        {
            _expense.Value = -10;

            MyResults results = _expense.Validate();

            Assert.True(results.Type == MyResultsType.Error);
        }
    }
}
