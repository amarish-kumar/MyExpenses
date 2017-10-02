/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.WinForm.Model
{
    using System;

    using MyExpenses.Application.DataTransferObject;

    public class ExpenseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

        public ExpenseModel()
        {
            
        }

        public ExpenseModel(ExpenseDto expenseDto)
        {
            Id = expenseDto.Id;
            Name = expenseDto.Name;
            Value = expenseDto.Value;
            Date = expenseDto.Date;
        }

        public ExpenseDto ConvertToDto()
        {
            return new ExpenseDto
            {
                Id = Id,
                Name = Name,
                Value = Value,
                Date = Date
            };
        }
    }
}
