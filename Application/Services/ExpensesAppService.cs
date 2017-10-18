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
        private readonly IExpensesService _expensesService;
        private readonly ITagsService _tagsService;

        private readonly IUnitOfWork _unitOfWork;

        public ExpensesAppService(IExpensesService expensesService, ITagsService tagsService, IUnitOfWork unitOfWork)
        {
            _expensesService = expensesService;
            _tagsService = tagsService;
            _unitOfWork = unitOfWork;
        }

        public List<ExpenseDto> GetAllExpenses()
        {
            // get expenses from domain
            List<Expense> expensesDomain = _expensesService.GetAll(x => x.Tags).ToList();
            // convert expenses to DTO
            List<ExpenseDto> expensesDto = expensesDomain.Select(x => new ExpenseDto(x)).ToList();

            return expensesDto;
        }

        public MyResults SaveOrUpdateExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();

            // save or update expenses
            MyResults results = _expensesService.SaveOrUpdate(expenseDto.ConvertToDomain());

            _unitOfWork.Commit();

            return results;
        }

        public MyResults RemoveExpense(ExpenseDto expenseDto)
        {
            _unitOfWork.BeginTransaction();

            // remove expense
            MyResults result = _expensesService.Remove(expenseDto.ConvertToDomain());

            _unitOfWork.Commit();

            return result;
        }
    }
}
