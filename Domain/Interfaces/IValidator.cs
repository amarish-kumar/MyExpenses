/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using MyExpenses.Util.Results;

    public interface IValidator
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <returns>Results of the validation</returns>
        MyResults Validate();
    }
}
