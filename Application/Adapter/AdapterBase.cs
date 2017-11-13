/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapter
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;

    public abstract class AdapterBase<TEntity, TDto> : IAdapter<TEntity, TDto>
        where TEntity : IDomain
        where TDto : IDto
    {
        public abstract TEntity ToDomain(TDto dto);

        public ICollection<TEntity> ToDomain(ICollection<TDto> dto)
        {
            return dto.Select(ToDomain).ToList();
        }

        public abstract TDto ToDto(TEntity domain);

        public ICollection<TDto> ToDto(ICollection<TEntity> domain)
        {
            return domain.Select(ToDto).ToList();
        }
    }
}
