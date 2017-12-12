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
        protected int StringMinSize => 3;

        protected int StringMaxSize => 128;

        protected void ValidateId(string msg)
        {
            RuleFor(x => x.Id)
                .LessThan(-1)
                .WithMessage(msg);
        }

        protected void ValidateName(Expression<Func<TDomain, string>> expression, string msg)
        {
            RuleFor(expression)
                .NotNull()
                .NotEmpty()
                .Length(StringMinSize, StringMaxSize)
                .WithMessage(msg);
        }

        protected void ValidateValue(Expression<Func<TDomain, float>> expression, string msg)
        {
            RuleFor(expression)
                .LessThan(0)
                .WithMessage(msg);
        }
    }
}
