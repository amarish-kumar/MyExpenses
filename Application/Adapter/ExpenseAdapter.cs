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
        public static Expense ToDomain(ExpenseDto expenseDto)
        {
            return new Expense
            {
                Id = expenseDto.Id,
                Name = expenseDto.Name,
                Value = expenseDto.Value,
                Date = expenseDto.Date,
                Tags = expenseDto.Tags.Select(TagAdapter.ToDomain).ToList()
            };
        }

        public static ExpenseDto ToDto(Expense expenseDomain)
        {
            ExpenseDto expenseDto = new ExpenseDto
            {
                Id = expenseDomain.Id,
                Name = expenseDomain.Name,
                Value = expenseDomain.Value,
                Date = expenseDomain.Date,
                Tags = expenseDomain.Tags.Select(TagAdapter.ToDto).ToList()
            };

            return expenseDto;
        }
    }
}
