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

    public class TagsRepositoryMock : RepositoryMock<Tag>, ITagsRepository
    {
        public TagsRepositoryMock(IMyContext context) : base(context)
        {
        }
    }
}
