/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Application.Interfaces
{
    using System.Collections.Generic;

    using Application.DataTransferObject;

    public interface IExpensesAppService
    {
        List<ExpensesDto> GetAllExpenses();
    }
}
