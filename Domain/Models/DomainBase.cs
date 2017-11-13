/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Util.Results;

    public abstract class DomainBase<TDomain> : IDomain where TDomain : IDomain
    {
        private readonly IValidator _validator;

        public long Id { get; set; }

        protected DomainBase(IValidator validator)
        {
            Id = 0;
            _validator = validator;
        }

        public virtual bool Copy(IDomain obj)
        {
            return true;
        }

        public virtual bool Equals(TDomain other)
        {
            return Id == other.Id;
        }

        public MyResults Validate()
        {
            return _validator != null ? 
                _validator.Validate(this) : 
                new MyResults(MyResultsType.Ok, Resources.Validation_OK);
        }
    }
}
