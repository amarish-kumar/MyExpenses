/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Adapters
{
    using MyExpenses.Application.Interfaces.Dtos;
    using MyExpenses.Domain.Interfaces;

    public interface IAdapter<TModel, TDto> where TModel : IModel where TDto : IDto
    {
        TDto ModelToDto(TModel model);

        TModel DtoToModel(TDto dto);
    }
}
