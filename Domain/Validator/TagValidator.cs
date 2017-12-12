/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;

    public class TagValidator : ValidatorBase<Tag>
    {
        public TagValidator()
        {
            ValidateId(string.Format(Resources.Validate_Id_Invalid, Resources.Tag));
            ValidateName(x => x.Name, string.Format(Resources.Validate_Field_Invalid, Resources.Tag, Resources.Name));
        }
    }
}
