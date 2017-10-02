/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Infrastructure.Repositories
{
    using Domain.Model;

    using Infrastructure.Context;
    using Infrastructure.Interfaces;

    public class ExpensesRepo : RepositoryBase<Expense>, IExpensesRepo
    {
        private readonly MyContext _context;

        public ExpensesRepo(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
