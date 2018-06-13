/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Adapters
{
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Models;

    public interface ILabelAdapter : IAdapter<Label, LabelDto>
    {
    }
}
