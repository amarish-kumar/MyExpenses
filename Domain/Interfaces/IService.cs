/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IService<TModel> where TModel : IModel
    {
        IEnumerable<TModel> Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes);

        TModel GetById(long id, params Expression<Func<TModel, object>>[] includes);

        bool Remove(TModel model);

        bool Remove(long id);

        TModel AddOrUpdate(TModel model);
    }
}
