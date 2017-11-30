/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.DataTransferObject
{
    using System;

    using MyExpenses.Application.Interfaces;

    public class ExpenseDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

        public TagDto Tag { get; set; }

        public ExpenseDto()
        {
        }
    }
}
