﻿/* 
*   Project: MyExpenses
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
        /// <param name="obj">Object to validate</param>
        /// <returns>Results of the validation</returns>
        MyResults Validate(IDomain obj);
    }
}
