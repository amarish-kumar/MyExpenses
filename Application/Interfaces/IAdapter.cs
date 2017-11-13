/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;

    public interface IAdapter<TEntity, TDto> 
        where TEntity : IEntity 
        where TDto : IDto
    {
        TEntity ToDomain(TDto dto);

        ICollection<TEntity> ToDomain(ICollection<TDto> dto);

        TDto ToDto(TEntity domain);

        ICollection<TDto> ToDto(ICollection<TEntity> domain);
    }
}
