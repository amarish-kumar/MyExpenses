/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapter
{
    using System.Linq;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Domain.Models;

    public static class ExpenseAdapter
    {
        public static Expense ToDomain(ExpenseDto dto)
        {
            return new Expense
            {
                Id = dto.Id,
                Name = dto.Name,
                Value = dto.Value,
                Date = dto.Date,
                Tags = dto.Tags.Select(TagAdapter.ToDomain).ToList()
            };
        }

        public static ExpenseDto ToDto(Expense domain)
        {
            return new ExpenseDto
            {
                Id = domain.Id,
                Name = domain.Name,
                Value = domain.Value,
                Date = domain.Date,
                Tags = domain.Tags.Select(TagAdapter.ToDto).ToList()
            };
        }
    }
}
