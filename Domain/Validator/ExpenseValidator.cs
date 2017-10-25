/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using System;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Util.Results;

    public class ExpenseValidator : IValidator<Expense>
    {
        public MyResults Validate(IEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidObject, Resources.Expense));
            }

            Expense expense = obj as Expense;

            if (expense == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidTypeObject, Resources.Expense));
            }

            MyResults results = new MyResults(MyResultsType.Ok, Resources.Validation_OK);

            if (expense.Id <= 0)
            {
                results = new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_Id_Invalid, Resources.Expense));
            }

            if (string.IsNullOrEmpty(expense.Name))
            {
                results = new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_String_Invalid, Resources.Expense, Resources.Name));
            }

            if (expense.Name.Length > 128)
            {
                results = new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_String_Invalid, Resources.Expense, Resources.Name));
            }

            return results;
        }
    }
}
