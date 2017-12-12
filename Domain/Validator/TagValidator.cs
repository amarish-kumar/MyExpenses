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

    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.Id)
                .LessThan(-1)
                .WithMessage(string.Format(Resources.Validate_Id_Invalid, Resources.Tag));

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 128)
                .WithMessage(string.Format(Resources.Validate_Field_Invalid, Resources.Tag, Resources.Name));
        }
    }
}
