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

    public abstract class EntityBase<TEntity> : IEntity where TEntity : class, IEntity
    {
        private readonly IValidator<TEntity> _validator;

        public long Id { get; set; }

        protected EntityBase(IValidator<TEntity> validator)
        {
            Id = 0;
            _validator = validator;
        }

        protected EntityBase()
        {
            Id = 0;
        }

        public abstract bool Copy(IEntity obj);

        public virtual bool Equals(TEntity other)
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
