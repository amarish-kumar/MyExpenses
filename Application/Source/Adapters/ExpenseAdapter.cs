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

    internal class ExpenseAdapter : IExpenseAdapter
    {
        public ExpenseDto ModelToDto(Expense model) => Mapper.Map<ExpenseDto>(model);

        public Expense DtoToModel(ExpenseDto dto) => Mapper.Map<Expense>(dto);
    }
}
