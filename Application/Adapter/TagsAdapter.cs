/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapter
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    public class TagsAdapter : AdapterBase<Tag, TagDto>, ITagsAdapter
    {
        public override Tag ToDomain(TagDto dto)
        {
            return new Tag
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public override TagDto ToDto(Tag domain)
        {
            return new TagDto
            {
                Id = domain.Id,
                Name = domain.Name
            };
        }
    }
}
