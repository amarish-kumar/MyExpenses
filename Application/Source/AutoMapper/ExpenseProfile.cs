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
                .ForMember(x => x.PaymentId, opt => { opt.MapFrom(src => src.PaymentId < 1 ? null : src.PaymentId); })
                .ReverseMap()
                .ForMember(x => x.LabelId, opt => { opt.MapFrom(src => src.LabelId < 1 ? null : src.LabelId); })
                .ForMember(x => x.PaymentId, opt => { opt.MapFrom(src => src.PaymentId < 1 ? null : src.PaymentId); });
        }
    }
}
