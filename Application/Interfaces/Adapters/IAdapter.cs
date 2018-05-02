/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Interfaces;

    public interface IAdapter<TModel, TDto> where TModel : IModel where TDto : IDto
    {
        TDto ModelToDto(TModel model);

        TModel DtoToModel(TDto dto);
    }
}
