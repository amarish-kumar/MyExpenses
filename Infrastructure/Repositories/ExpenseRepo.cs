/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Repositories
{
    using Domain.Interfaces.Repositories;
    using Domain.Model;

    using Infrastructure.Context;

    public class ExpenseRepo : RepositoryBase<Expense>, IExpenseRepo
    {
        private readonly MyContext _context;

        public ExpenseRepo(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
