/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;

    public class TagsAppService : AppServiceBase<Tag, TagDto>, ITagsAppService<TagDto>
    {
        public TagsAppService(ITagsService domainService, IUnitOfWork unitOfWork, IAdapter<Tag, TagDto> adapter) :
            base(domainService, unitOfWork, adapter)
        {
        }
    }
}
