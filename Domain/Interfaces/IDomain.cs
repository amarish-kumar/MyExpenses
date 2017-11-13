/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using MyExpenses.Util.Results;

    public interface IDomain
    {
        long Id { get; set; }

        bool Copy(IDomain obj);

        MyResults Validate();
    }
}
