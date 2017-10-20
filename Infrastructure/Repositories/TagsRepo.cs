/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;

    public class TagsRepo : RepositoryBase<Tag>, ITagsRepo
    {
        public TagsRepo(IMyContext context) : base(context)
        {
        }
    }
}
