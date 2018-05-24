/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using MyExpenses.Application.Interfaces.Dtos;

    public class LabelDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
