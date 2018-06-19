/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using MyExpenses.Application.Interfaces.Dtos;
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;

    public interface IAppService<TModel> where TModel : IDto
    {
        /// <summary>
        /// Get all objects <see cref="IService{TModel}"/>
        /// </summary>
        /// <returns>All objects</returns>
        IEnumerable<TModel> Get();

        /// <summary>
        /// Get object by Id <see cref="IService{TModel}"/>
        /// </summary>
        /// <param name="id">Id of the object to be find</param>
        /// <returns></returns>
        TModel GetById(long id);

        /// <summary>
        /// Remove object <see cref="IService{TModel}"/>
        /// </summary>
        /// <param name="id">If of the object to remove</param>
        /// <returns>True if could remove and false otherwise</returns>
        bool Remove(long id);

        /// <summary>
        /// Add an object <see cref="IService{TModel}"/>
        /// </summary>
        /// <param name="model">Object to add</param>
        /// <returns>Object added</returns>
        TModel Add(TModel model);

        /// <summary>
        /// Update an object <see cref="IService{TModel}"/>
        /// </summary>
        /// <param name="model">Object toupdate</param>
        /// <returns>Object updated</returns>
        TModel Update(TModel model);
    }
}
