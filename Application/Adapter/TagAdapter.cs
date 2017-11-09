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
        public static Tag ToDomain(TagDto expenseDto)
        {
            return new Tag
            {
                Id = expenseDto.Id,
                Name = expenseDto.Name,
            };
        }

        public static TagDto ToDto(Tag tagDomain)
        {
            return new TagDto
            {
                Id = tagDomain.Id,
                Name = tagDomain.Name,
            };
        }
    }
}
