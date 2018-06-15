/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.InfrastructureTest.Repositories
{
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.InfrastructureTest.Context;

    public class LabelRepository : RepositoryBase<Label>, ILabelRepository
    {
        public LabelRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
