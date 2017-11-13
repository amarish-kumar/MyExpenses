/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.DataTransferObject;

    public class ExpenseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

        public ICollection<TagModel> Tags { get; set; }

        public ExpenseModel()
        {
            Tags = new List<TagModel>();
        }

        public static ExpenseModel ToModel(ExpenseDto dto)
        {
            return new ExpenseModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Value = dto.Value,
                Date = dto.Date,
                Tags = dto.Tags.Select(TagModel.ToModel).ToList()
            };
        }

        public static ExpenseDto ToDto(ExpenseModel model)
        {
            return new ExpenseDto
            {
                Id = model.Id,
                Name = model.Name,
                Value = model.Value,
                Date = model.Date,
                Tags = model.Tags.Select(TagModel.ToDto).ToList()
            };
        }
    }
}