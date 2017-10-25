/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using MyExpenses.Util.Results;

    public interface IEntity
    {
        long Id { get; set; }

        bool Copy(IEntity obj);

        MyResults Validate();
    }
}
