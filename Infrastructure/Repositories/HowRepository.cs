/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Interfaces;

    public class HowRepository : RepositoryBase<How>, IHowRepository
    {
        public HowRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
