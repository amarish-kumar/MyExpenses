/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Mocks
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;

    public class RepositoryMock<TDomain> : Repository<TDomain> where TDomain : class, IDomain
    {
        public RepositoryMock(IMyContext context) : base(context, null)
        {
        }
    }
}
