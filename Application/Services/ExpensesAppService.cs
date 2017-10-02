/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Infrastructure.Interfaces;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Models;

    public class ExpensesAppService : AppServiceBase, IExpensesAppService
    {
        private readonly IExpensesRepo _repo;

        public ExpensesAppService(IExpensesRepo repo)
        {
            _repo = repo;
        }

        public List<ExpensesDto> GetAllExpenses()
        {
            List<Expense> expensesDomain = _repo.GetAll().ToList();
            List<ExpensesDto> expensesDto = expensesDomain.Select(
                x => new ExpensesDto
                         {
                             Id = x.Id,
                             Name = x.Name,
                             Value = x.Value,
                             Date = x.Date
                         }).ToList();

            return expensesDto;
        }
    }
}
