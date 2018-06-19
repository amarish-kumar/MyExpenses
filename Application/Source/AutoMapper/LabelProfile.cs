/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AutoMapper
{
    using global::AutoMapper;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Models;

    internal class LabelProfile : Profile
    {
        public LabelProfile() => CreateMap<Label, LabelDto>().ReverseMap();
    }
}
