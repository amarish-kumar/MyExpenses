/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Application.Interfaces.Dtos;

    public class PaymentDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
