/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapter
{
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
                Date = expenseDto.Date
            };
        }

        public static ExpenseDto ToDto(Expense expenseDomain)
        {
            return new ExpenseDto
            {
                Id = expenseDomain.Id,
                Name = expenseDomain.Name,
                Value = expenseDomain.Value,
                Date = expenseDomain.Date
            };
        }
    }
}
