/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    public class ExpensesAppService : IExpensesAppService
    {
        private readonly IExpensesService _expensesService;
        private readonly IUnitOfWork _unitOfWork;

        public ExpensesAppService(IExpensesService expensesService, IUnitOfWork unitOfWork)
        {
            _expensesService = expensesService;
            _unitOfWork = unitOfWork;
        }

        public List<ExpenseDto> GetAllExpenses()
        {
            // Get expenses from domain
            List<Expense> expensesDomain = _expensesService.GetAll(x => x.Tags).ToList();

            // Convert expenses to DTO
            List<ExpenseDto> expensesDto = expensesDomain.Select(x => new ExpenseDto(x)).ToList();

            return expensesDto;
        }

        public MyResults SaveOrUpdateExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();

            // Save or update expenses
            MyResults results = _expensesService.SaveOrUpdate(expenseDto.ConvertToDomain());

            _unitOfWork.Commit();

            return results;
        }

        public MyResults RemoveExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();

            // Remove expense
            MyResults result = _expensesService.Remove(expenseDto.ConvertToDomain());

            _unitOfWork.Commit();

            return result;
        }
    }
}
