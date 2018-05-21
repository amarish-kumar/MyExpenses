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
    using MyExpenses.Application.ViewModels;

    public interface ILabelAppService : IAppService<LabelDto>
    {
        IEnumerable<LabelViewModel> GetAll(DateTime starDateTime, DateTime endDateTime);
    }
}
