/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Mocks
{
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;

    public class ExpensesRepositoryMock : RepositoryMock<Expense>, IExpensesRepository
    {
        public ExpensesRepositoryMock(IMyContext context) : base(context)
        {   
        }
    }
}
