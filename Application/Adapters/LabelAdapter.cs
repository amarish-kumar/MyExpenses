/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    internal class LabelAdapter : ILabelAdapter
    {
        public LabelDto ModelToDto(Label model)
        {
            if (model == null)
                return null;

            return new LabelDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public Label DtoToModel(LabelDto dto)
        {
            if (dto == null)
                return null;

            return new Label
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
