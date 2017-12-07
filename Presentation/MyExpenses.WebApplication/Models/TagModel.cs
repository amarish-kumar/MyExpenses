/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Presentaion.WebApplication.Models
{
    using MyExpenses.Application.DataTransferObject;

    public class TagModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public static TagModel ToModel(TagDto dto)
        {
            return new TagModel
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static TagDto ToDto(TagModel model)
        {
            return new TagDto
            {
                Id = model.Id,  
                Name = model.Name
            };
        }
    }
}