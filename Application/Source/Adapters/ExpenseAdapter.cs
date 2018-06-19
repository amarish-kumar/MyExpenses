/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using global::AutoMapper;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    internal class ExpenseAdapter : IExpenseAdapter
    {
        public ExpenseDto ModelToDto(Expense model) => Mapper.Map<ExpenseDto>(model);

        public Expense DtoToModel(ExpenseDto dto) => Mapper.Map<Expense>(dto);
    }
}
