/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Util.Results;

    public abstract class DomainBase<TDomain> : IDomain, ICloneable, IEquatable<TDomain>, IEqualityComparer<TDomain>
        where TDomain : class, IDomain
    {
        /// <summary>
        /// Validator class
        /// </summary>
        private readonly IValidator _validator;

        /// <summary>
        /// Identification
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validator" cref="IValidator">Validator</param>
        protected DomainBase(IValidator validator)
        {
            Id = 0;
            _validator = validator;
        }

        /// <summary>
        /// Validate class
        /// </summary>
        /// <returns cref="MyResults">Result of validation</returns>
        public MyResults Validate()
        {
            return _validator != null ? 
                _validator.Validate(this) : 
                new MyResults(MyResultsStatus.Ok, MyResultsAction.Validating);
        }

        /// <summary>
        /// My implementation of copy
        /// </summary>
        public abstract bool MyCopy(TDomain other);

        /// <summary>
        /// My implementation of clone
        /// </summary>
        public abstract TDomain MyClone();

        /// <summary>
        /// My implementation of equal
        /// </summary>
        public abstract bool MyEqual(TDomain other);

        #region override Copy/Clone/Equal/Equals

        public virtual bool Copy(IDomain other)
        {
            return MyCopy(other as TDomain);
        }

        public virtual IDomain Clone()
        {
            return MyClone();
        }

        object ICloneable.Clone()
        {
            return MyClone();
        }

        public virtual bool Equal(IDomain other)
        {
            return MyEqual(other as TDomain);
        }

        public bool Equals(TDomain other)
        {
            return MyEqual(other);
        }

        public bool Equals(TDomain x, TDomain y)
        {
            if (x == null || y == null)
                return false;
            return x.Equals(y);
        }

        public int GetHashCode(TDomain obj)
        {
            return obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = -58299164;
            hashCode = hashCode * -1521134295 + EqualityComparer<IValidator>.Default.GetHashCode(_validator);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }

        #endregion
    }
}
