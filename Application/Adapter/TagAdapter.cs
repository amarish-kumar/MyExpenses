/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapter
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Domain.Models;

    public static class TagAdapter
    {
        public static Tag ToDomain(TagDto dto)
        {
            return new Tag
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }

        public static TagDto ToDto(Tag domain)
        {
            return new TagDto
            {
                Id = domain.Id,
                Name = domain.Name,
            };
        }
    }
}
