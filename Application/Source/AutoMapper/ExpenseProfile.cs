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

    internal class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDto>()
                .ForMember(x => x.LabelId, opt => { opt.MapFrom(src => src.LabelId < 1 ? null : src.LabelId); })
                .ForMember(x => x.Label, opt => { opt.MapFrom(src => Mapper.Map<LabelDto>(src.Label)); })
                .ForMember(x => x.PaymentId, opt => { opt.MapFrom(src => src.PaymentId < 1 ? null : src.PaymentId); })
                .ForMember(x => x.Payment, opt => { opt.MapFrom(src => Mapper.Map<PaymentDto>(src.Payment)); })
                .ReverseMap()
                .ForMember(x => x.LabelId, opt => { opt.MapFrom(src => src.LabelId < 1 ? null : src.LabelId); })
                .ForMember(x => x.Label, opt => { opt.MapFrom(src => Mapper.Map<Label>(src.Label)); })
                .ForMember(x => x.PaymentId, opt => { opt.MapFrom(src => src.PaymentId < 1 ? null : src.PaymentId); })
                .ForMember(x => x.Payment, opt => { opt.MapFrom(src => Mapper.Map<Payment>(src.Payment)); });
        }
    }
}
