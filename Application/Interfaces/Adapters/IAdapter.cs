/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Adapters
{
    using MyExpenses.Application.Interfaces.Dtos;
    using MyExpenses.Domain.Interfaces;

    /// <summary>
    /// Convert domain model in dto and vice versa
    /// </summary>
    /// <typeparam name="TModel">Domain model <see cref="IModel"/></typeparam>
    /// <typeparam name="TDto">Dto model <see cref="IDto"/></typeparam>
    public interface IAdapter<TModel, TDto> where TModel : IModel where TDto : IDto
    {
        /// <summary>
        /// Convert model into dto
        /// </summary>
        /// <param name="model">Domain object</param>
        /// <returns>Dto object</returns>
        TDto ModelToDto(TModel model);

        /// <summary>
        /// Convert dto into domain model
        /// </summary>
        /// <param name="dto">Dto object</param>
        /// <returns>Domain object</returns>
        TModel DtoToModel(TDto dto);
    }
}
