/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    using System.Collections.Generic;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Util.Results;

    public interface ITagsAppService
    {
        /// <summary>
        /// Get all tags available
        /// </summary>
        /// <returns cref="TagDto">All tags</returns>
        List<TagDto> GetAllTags();

        /// <summary>
        /// Save or update a tag
        /// </summary>
        /// <param name="tagDto" cref="TagDto">Tag to be save or updated</param>
        /// <returns>Result of the operation</returns>
        MyResults SaveOrUpdateTag(TagDto TagDto);

        /// <summary>
        /// Remove tag
        /// </summary>
        /// <param name="tagDto" cref="TagDto">Tag to be removed</param>
        /// <returns>Result of the operation</returns>
        MyResults RemoveTag(TagDto tagDto);
    }
}
