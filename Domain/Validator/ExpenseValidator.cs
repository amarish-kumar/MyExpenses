/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;

    public class ExpenseValidator : ValidatorBase<Expense>
    {
        public ExpenseValidator()
        {
            ValidateId(string.Format(Resources.Validate_Id_Invalid, Resources.Expense));
            ValidateName(x => x.Name, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Name));
            ValidateValue(x => x.Value, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Value));
        }
    }
}
