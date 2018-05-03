/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System.Collections.Generic;

    using MyExpenses.Application.Interfaces.Dtos;

    public interface IAppService<TModel> where TModel : IDto
    {
        IEnumerable<TModel> GetAll();

        TModel GetById(long id);

        bool Remove(TModel model);

        bool Remove(long id);

        TModel AddOrUpdate(TModel model);
    }
}
