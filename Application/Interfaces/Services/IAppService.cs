/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System.Collections.Generic;

    using MyExpenses.Util.Results;
    using System.Linq.Expressions;
    using System;
    using MyExpenses.Domain.Interfaces;

    public interface IAppService<TDomain, TDto>
        where TDomain : IDomain
        where TDto : IDto 
    {
        TDto GetById(long id);

        ICollection<TDto> GetAll(params Expression<Func<TDomain, object>>[] includes);

        ICollection<TDto> Get(Expression<Func<TDomain, bool>> filter, params Expression<Func<TDomain, object>>[] includes);

        MyResults AddOrUpdate(TDto dto);

        MyResults AddOrUpdate(ICollection<TDto> dtos);

        MyResults Remove(TDto dto);

        MyResults Remove(ICollection<TDto> dtos);
    }
}
