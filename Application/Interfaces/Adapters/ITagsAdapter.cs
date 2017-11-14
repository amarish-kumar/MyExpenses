/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Adapters
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Domain.Models;

    public interface ITagsAdapter : IAdapter<Tag, TagDto>
    {
    }
}
