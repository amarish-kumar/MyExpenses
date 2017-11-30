/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.DataTransferObject
{
    using MyExpenses.Application.Interfaces;

    public class TagDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
