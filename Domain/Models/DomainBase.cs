/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Util.Results;

    public abstract class DomainBase : IDomain
    {
        private readonly IValidator _validator;

        public long Id { get; set; }

        protected DomainBase(IValidator validator)
        {
            Id = 0;
            _validator = validator;
        }

        public MyResults Validate()
        {
            return _validator != null ? 
                _validator.Validate(this) : 
                new MyResults(MyResultsType.Ok, MyResultsAction.Validating);
        }

        public virtual bool Copy(IDomain other)
        {
            Id = other.Id;
            return true;
        }

        public virtual IDomain Clone()
        {
            return default(IDomain);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public virtual bool Equal(IDomain other)
        {
            return Id == other?.Id;
        }        
    }
}
