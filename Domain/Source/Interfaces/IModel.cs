/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    /// <summary>
    /// Base interface for domain model
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Identification key
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Copy method
        /// </summary>
        /// <param name="obj">Object to copy from</param>
        void Copy(IModel obj);
    }
}
