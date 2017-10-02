/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Application.DataTransferObject;
    using Application.Interfaces;

    using Domain.Model;

    using Infrastructure.Interfaces;

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
