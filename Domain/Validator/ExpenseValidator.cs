/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Util.Results;

    public class ExpenseValidator : IValidator<Expense>
    {
        public MyResults Validate(IEntity obj)
        {
            Expense expense = obj as Expense;

            MyResults results = new MyResults(MyResultsType.Ok, Resources.Validation_OK);

            if (expense.Id <= 0)
            {
                results = new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_Id_Invalid, Resources.Tag));
            }

            if (string.IsNullOrEmpty(expense.Name))
            {
                results = new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_String_Invalid, Resources.Tag, Resources.Name));
            }

            if (expense.Name.Length > 128)
            {
                results = new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_String_Invalid, Resources.Tag, Resources.Name));
            }

            return results;
        }
    }
}
