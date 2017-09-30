/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Domain.Interfaces.Repositories;
    using Domain.Model;

    using Infrastructure.Context;

    public class ExpenseRepo : IExpenseRepo
    {
        private readonly MyContext _context;

        public ExpenseRepo(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetAll()
        {
            IQueryable<Expense> set = _context.Expenses;
            return set;
        }
    }
}
