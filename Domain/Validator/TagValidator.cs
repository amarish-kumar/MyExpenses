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

    public class TagValidator : IValidator<Tag>
    {
        public MyResults Validate(IEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidObject, Resources.Tag));
            }

            Tag tag = obj as Tag;

            if (tag == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidTypeObject, Resources.Tag));
            }

            if (tag.Id <= 0)
            {
                return new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_Id_Invalid, Resources.Tag));
            }

            if (string.IsNullOrEmpty(tag.Name))
            {
                return new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_Field_Invalid, Resources.Tag, Resources.Name));
            }

            if (tag.Name.Length > 128)
            {
                return new MyResults(MyResultsType.Error, Resources.Validation_Error, string.Format(Resources.Validate_Field_Invalid, Resources.Tag, Resources.Name));
            }

            return new MyResults(MyResultsType.Ok, Resources.Validation_OK);
        }
    }
}
