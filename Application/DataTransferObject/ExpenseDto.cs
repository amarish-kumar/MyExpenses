/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.DataTransferObject
{
    using System;
    using System.Collections.Generic;

    public class ExpenseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

        public ICollection<TagDto> Tags { get; set; }

        public ExpenseDto()
        {
            Tags = new List<TagDto>();
        }
    }
}
