/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using System;
    using System.Linq.Expressions;
    using FluentValidation;
    using MyExpenses.Domain.Interfaces;

    public abstract class ValidatorBase<TDomain> : AbstractValidator<TDomain> where TDomain : IDomain
    {
        private const long ID_MIN_VALUE = 0;
        private const int STRING_MIN_SIZE = 3;
        private const int STRING_MAX_SIZE = 128;
        private const float FLOAT_MIN_VALUE = 0.0f;

        protected void ValidateId(string msg)
        {
            RuleFor(x => x.Id)
                .LessThan(ID_MIN_VALUE)
                .WithMessage(msg);
        }

        protected void ValidateName(Expression<Func<TDomain, string>> expression, string msg)
        {
            RuleFor(expression)
                .NotNull()
                .NotEmpty()
                .Length(STRING_MIN_SIZE, STRING_MAX_SIZE)
                .WithMessage(msg);
        }

        protected void ValidateValue(Expression<Func<TDomain, float>> expression, string msg)
        {
            RuleFor(expression)
                .LessThan(FLOAT_MIN_VALUE)
                .WithMessage(msg);
        }
    }
}
