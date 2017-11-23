/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using System;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Util.Results;

    public class TagValidator : IValidator
    {
        private readonly Tag _domain;

        public TagValidator(Tag obj)
        {
            _domain = obj;
        }

        public MyResults Validate()
        {
            if (_domain == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidObject, Resources.Tag));
            }

            if (_domain.Id < 0)
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Id_Invalid, Resources.Tag));
            }

            if (string.IsNullOrEmpty(_domain.Name))
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Field_Invalid, Resources.Tag, Resources.Name));
            }

            if (_domain.Name.Length > 128)
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Field_Invalid, Resources.Tag, Resources.Name));
            }

            return new MyResults(MyResultsStatus.Ok, MyResultsAction.Validating);
        }
    }
}
