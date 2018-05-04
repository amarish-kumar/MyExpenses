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
        /// e.g. Get all persons with more than 20 years
        /// 
        /// IPersonService p;
        /// var lst = p.Get(x => x.Age > 20, x => x.Address);
        /// 
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="includes">Include expression</param>
        /// <returns>Set of objects</returns>
        IEnumerable<TModel> Get(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);

        /// <summary>
        /// Get all objects
        /// 
        /// e.g. Get all persons and load the address
        /// 
        /// IPersonService p;
        /// var lst = p.GetAll(x => x.Address);
        /// 
        /// </summary>
        /// <param name="includes">Include expression</param>
        /// <returns>All objects</returns>
        IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes);

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
        /// <param name="model">Object to remove</param>
        /// <returns>True if could remove and false otherwise</returns>
        bool Remove(TModel model);

        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="id">If of the object to remove</param>
        /// <returns>True if could remove and false otherwise</returns>
        bool Remove(long id);

        /// <summary>
        /// Add or update an object
        /// 
        /// If the key (Id) is positive (greater than zero) will update the object
        /// If the key (Id) is less than zero will add as a new object
        /// 
        /// </summary>
        /// <param name="model">Object to add or update</param>
        /// <returns>Object added or updated</returns>
        TModel AddOrUpdate(TModel model);
    }
}
