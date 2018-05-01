/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class LabelService : ServiceBase<Label>, ILabelService
    {
        public LabelService(ILabelRepository repository)
            : base(repository)
        {
        }
    }
}
