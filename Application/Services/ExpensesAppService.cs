/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.CrossCutting.Results;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;

    public class ExpensesAppService : AppServiceBase, IExpensesAppService
    {
        private readonly IExpensesService _service;

        private readonly IUnitOfWork _unitOfWork;

        public ExpensesAppService(IExpensesService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public List<ExpenseDto> GetAllExpenses()
        {
            List<Expense> expensesDomain = _service.GetAll().ToList();
            List<ExpenseDto> expensesDto = expensesDomain.Select(x => new ExpenseDto(x)).ToList();

            return expensesDto;
        }

        public MyResults SaveOrUpdateExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();
            MyResults results = _service.SaveOrUpdate(expenseDto.ConvertToDomain());
            _unitOfWork.Commit();

            return results;
        }

        public MyResults RemoveExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();
            MyResults result = _service.Remove(expenseDto.ConvertToDomain());
            _unitOfWork.Commit();

            return result;
        }
    }
}
