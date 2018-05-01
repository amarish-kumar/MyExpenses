/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;

    public class LabelAppService : AppServiceBase<Label>, ILabelAppService
    {
        public LabelAppService(IService<Label> service, IUnitOfWork unitOfWork)
            : base(service, unitOfWork)
        {
        }
    }
}
