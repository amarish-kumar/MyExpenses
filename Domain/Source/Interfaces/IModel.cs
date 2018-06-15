/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using MyExpenses.Domain.Models;

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

        // TODO
        //long? CreatedUserId { get; set; }
        //User CreatedUser { get; set; }

        //long? LastUpdateUserId { get; set; }
        //User LastUpdateUser { get; set; }
    }
}
