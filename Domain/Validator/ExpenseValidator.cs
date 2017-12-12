/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using FluentValidation;

    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;

    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.Id)
                .LessThan(-1)
                    .WithMessage(string.Format(Resources.Validate_Id_Invalid, Resources.Expense));

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 128)
                    .WithMessage(string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Name));

            RuleFor(x => x.Value)
                .LessThan(0)
                .WithMessage(string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Value));
        }
    }
}
