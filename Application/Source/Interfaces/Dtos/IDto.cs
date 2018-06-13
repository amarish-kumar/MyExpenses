/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Dtos
{
    /// <summary>
    /// DTO - data transfer object - object that carries data between processes
    /// </summary>
    public interface IDto
    {
        /// <summary>
        /// Identification key
        /// </summary>
        long Id { get; set; }
    }
}
