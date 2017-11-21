/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using System;

    using MyExpenses.Util.Results;

    public interface IDomain : ICloneable
    {
        long Id { get; set; }

        bool Copy(IDomain other);

        new IDomain Clone();

        bool Equal(IDomain other);

        MyResults Validate();
    }
}
