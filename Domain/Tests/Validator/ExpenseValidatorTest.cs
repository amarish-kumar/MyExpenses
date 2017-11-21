/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Validator
{
    using System;

    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Domain.Validator;
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
                Date = new DateTime()
            };
        }

        [Test]
        public static void TestExpenseValidator_Invalid()
        {
            ExpenseValidator expenseValidator = new ExpenseValidator();
            Assert.Throws<ArgumentException>(() => expenseValidator.Validate(null));
            Assert.Throws<ArgumentException>(() => expenseValidator.Validate(new Tag()));
        }

        [Test]
        public void TestExpenseValidator_Validate_Ok()
        {
            MyResults results = _expense.Validate();

            Assert.AreEqual(results.Status, MyResultsStatus.Ok);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
        }

        [Test]
        public void TestExpenseValidator_IdIsInvalid_Validate_ResultError()
        {
            _expense.Id = -1;

            MyResults results = _expense.Validate();

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
            Assert.AreEqual(results.Message, string.Format(Resources.Validate_Id_Invalid, Resources.Expense));
        }

        [Test]
        public void TestExpenseValidator_NameIsEmtpy_Validate_ResultError()
        {
            _expense.Name = string.Empty;

            MyResults results = _expense.Validate();

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
            Assert.AreEqual(results.Message, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Name));
        }

        [Test]
        public void TestExpenseValidator_NameIsTooBig_Validate_ResultError()
        {
            _expense.Name = new string('a', 129);

            MyResults results = _expense.Validate();

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
            Assert.AreEqual(results.Message, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Name));
        }

        [Test]
        public void TestExpenseValidator_InvalidValue_Validate_ResultError()
        {
            _expense.Value = -10;

            MyResults results = _expense.Validate();

            Assert.AreEqual(results.Status, MyResultsStatus.Error);
            Assert.AreEqual(results.Action, MyResultsAction.Validating);
            Assert.AreEqual(results.Message, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Value));
        }
    }
}
