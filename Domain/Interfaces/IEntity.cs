/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Domain.Interfaces
{
    public interface IEntity
    {
        long Id { get; set; }

        bool Equals(IEntity obj);

        bool Copy(IEntity obj);
    }
}
