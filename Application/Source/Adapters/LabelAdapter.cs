/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using AutoMapper;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    internal class LabelProfile : Profile
    {
        public LabelProfile()
        {
            CreateMap<Label, LabelDto>().ReverseMap();
        }
    }

    internal class LabelAdapter : ILabelAdapter
    {
        public LabelDto ModelToDto(Label model) => Mapper.Map<LabelDto>(model);

        public Label DtoToModel(LabelDto dto) => Mapper.Map<Label>(dto);
    }
}
