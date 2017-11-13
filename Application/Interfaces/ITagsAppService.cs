/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    public interface ITagsAppService<TDto> : IAppService<TDto> where TDto : IDto
    {
    }
}
