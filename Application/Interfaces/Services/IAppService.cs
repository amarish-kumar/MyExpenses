/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System.Collections.Generic;

    using MyExpenses.Util.Results;

    public interface IAppService<TDto> where TDto : IDto 
    {
        TDto GetById(long id);

        ICollection<TDto> GetAll();

        MyResults AddOrUpdate(TDto dto);

        MyResults Remove(TDto dto);
    }
}
