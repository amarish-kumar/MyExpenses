/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    public interface IExpensesAppService<TDto> : IAppService<TDto> where TDto : IDto 
    {
    }
}
