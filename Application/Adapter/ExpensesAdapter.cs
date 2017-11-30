/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapter
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;

    public class ExpensesAdapter : AdapterBase<Expense, ExpenseDto>, IExpensesAdapter
    {
        private readonly ITagsAdapter _tagAdapter;

        public ExpensesAdapter(ITagsAdapter tagAdapter)
        {
            _tagAdapter = tagAdapter;
        }

        /// <summary>
        /// Adapter from dto to domain
        /// </summary>
        /// <param name="dto" cref="ExpenseDto">Dto class</param>
        /// <returns cref="Expense">Domain class</returns>
        public override Expense ToDomain(ExpenseDto dto)
        {
            return new Expense
            {
                Id = dto.Id,
                Name = dto.Name,
                Value = dto.Value,
                Date = dto.Date,
                Tag = dto.Tag != null ? _tagAdapter.ToDomain(dto.Tag) : null
            };
        }

        /// <summary>
        /// Adapter from domain to dto
        /// </summary>
        /// <param name="domain" cref="Expense">Domain class</param>
        /// <returns cref="ExpenseDto">Dto class</returns>
        public override ExpenseDto ToDto(Expense domain)
        {
            return new ExpenseDto
            {
                Id = domain.Id,
                Name = domain.Name,
                Value = domain.Value,
                Date = domain.Date,
                Tag = domain.Tag != null ? _tagAdapter.ToDto(domain.Tag) : null
            };
        }
    }
}
