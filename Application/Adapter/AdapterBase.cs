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

    public abstract class AdapterBase<TDomain, TDto> : IAdapter<TDomain, TDto>
        where TDomain : IDomain
        where TDto : IDto
    {
        public abstract TDomain ToDomain(TDto dto);

        public ICollection<TDomain> ToDomain(ICollection<TDto> dto) => dto.Select(ToDomain).ToList();

        public abstract TDto ToDto(TDomain domain);

        public ICollection<TDto> ToDto(ICollection<TDomain> domain) => domain.Select(ToDto).ToList();
    }
}
