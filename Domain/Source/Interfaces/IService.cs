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

    /// <summary>
    /// Service interface
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IService<TModel> where TModel : IModel
    {
        /// <summary>
        /// Get set of objects
        /// 
        /// e.g. Get all persons
        /// 
        /// IPersonService p;
        /// var lst = p.Get(x => x.Address);
        /// 
        /// </summary>
        /// <param name="includes">Include expression</param>
        /// <returns>Set of objects</returns>
        IEnumerable<TModel> Get(params Expression<Func<TModel, object>>[] includes);

        /// <summary>
        /// Get object by Id
        /// 
        /// e.g. Get person with id 10
        /// 
        /// IPersonService p;
        /// var person = p.GetById(10, x => x.Address);
        /// 
        /// </summary>
        /// <param name="id">Id of the object to be find</param>
        /// <param name="includes">Include expression</param>
        /// <returns></returns>
        TModel GetById(long id, params Expression<Func<TModel, object>>[] includes);

        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="id">If of the object to remove</param>
        /// <returns>True if could remove and false otherwise</returns>
        bool Remove(long id);

        /// <summary>
        /// Add an object
        /// </summary>
        /// <param name="model">Object to add</param>
        /// <returns>Object added</returns>
        TModel Add(TModel model);

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="model">Object to update</param>
        /// <returns>Object updated</returns>
        TModel Update(TModel model);
    }
}
