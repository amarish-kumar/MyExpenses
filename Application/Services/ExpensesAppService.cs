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
    using MyExpenses.CrossCutting.Results;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;

    public class ExpensesAppService : AppServiceBase, IExpensesAppService
    {
        private readonly IExpensesRepo _repo;

        private readonly IUnitOfWork _unitOfWork;

        public ExpensesAppService(IExpensesRepo repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public List<ExpenseDto> GetAllExpenses()
        {
            List<Expense> expensesDomain = _repo.GetAll().ToList();
            List<ExpenseDto> expensesDto = expensesDomain.Select(x => new ExpenseDto(x)).ToList();

            return expensesDto;
        }

        public MyResults SaveOrUpdateExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();
            MyResults results = _repo.SaveOrUpdate(expenseDto.ConvertToDomain());
            _unitOfWork.Commit();

            return results;
        }

        public MyResults RemoveExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();
            MyResults result = _repo.Remove(expenseDto.ConvertToDomain());
            _unitOfWork.Commit();

            return result;
        }
    }
}
