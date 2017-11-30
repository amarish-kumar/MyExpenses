/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;

    public interface IAdapter<TDomain, TDto> 
        where TDomain : IDomain 
        where TDto : IDto
    {
        TDomain ToDomain(TDto dto);

        ICollection<TDomain> ToDomain(ICollection<TDto> dto);

        TDto ToDto(TDomain domain);

        ICollection<TDto> ToDto(ICollection<TDomain> domain);
    }
}
