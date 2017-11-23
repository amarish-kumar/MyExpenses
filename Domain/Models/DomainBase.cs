/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Util.Results;

    public abstract class DomainBase<TDomain> : IDomain, ICloneable
        where TDomain : class, IDomain
    {
        /// <summary>
        /// Identification
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected DomainBase()
        {
            Id = 0;
            Validator = null;
        }

        /// <summary>
        /// Validate class
        /// </summary>
        /// <returns cref="MyResults">Result of validation</returns>
        public MyResults Validate()
        {
            return Validator != null ? 
                Validator.Validate() : 
                new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, Resources.Validation_MissingValidator);
        }

        /// <summary>
        /// Validator class
        /// </summary>
        protected IValidator Validator;

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

        #endregion
    }
}
