/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    public interface IModel
    {
        long Id { get; set; }

        void Copy(IModel obj);
    }
}
