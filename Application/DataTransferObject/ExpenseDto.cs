/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.DataTransferObject
{
    using System;

    using MyExpenses.Domain.Models;

    public class ExpenseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

        public ExpenseDto()
        {
            
        }

        public ExpenseDto(Expense expenseDomain)
        {
            Id = expenseDomain.Id;
            Name = expenseDomain.Name;
            Value = expenseDomain.Value;
            Date = expenseDomain.Date;
        }

        public Expense ConvertToDomain()
        {
            return new Expense
            {
                Id = Id,
                Name = Name,
                Value = Value,
                Date = Date
            };
        }
    }
}
