/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Application.Dtos;

    public interface ILabelAppService : IAppService<LabelDto>
    {
        IEnumerable<IndexLabelDto> Get(DateTime starDateTime, DateTime endDateTime);
    }
}
