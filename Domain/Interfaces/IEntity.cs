/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using MyExpenses.Domain.Validator;

    public interface IEntity : IValidator
    {
        long Id { get; set; }

        bool Equals(IEntity obj);

        bool Copy(IEntity obj);
    }
}
