/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Modules
{
    using Moq;

    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;

    using Ninject.Modules;

    public class MyApplicationModuleMock : NinjectModule
    {
        private readonly Mock<IExpensesService> _expenseServiceMock;
        private readonly Mock<ITagsService> _tagServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public MyApplicationModuleMock(
            Mock<IExpensesService> expenseServiceMock, 
            Mock<ITagsService> tagServiceMock, 
            Mock<IUnitOfWork> unitOfWorkMock)
        {
            _expenseServiceMock = expenseServiceMock;
            _tagServiceMock = tagServiceMock;
            _unitOfWorkMock = unitOfWorkMock;
        }

        public override void Load()
        {
            Bind<IExpensesAppService<ExpenseDto>>().To<ExpensesAppService>();
            Bind<ITagsAppService<TagDto>>().To<TagsAppService>();

            Bind<IAdapter<Expense, ExpenseDto>>().To<ExpensesAdapter>();
            Bind<IAdapter<Tag, TagDto>>().To<TagsAdapter>();

            if (_expenseServiceMock != null)
                Bind<IExpensesService>().ToConstant(_expenseServiceMock.Object);

            if(_tagServiceMock != null)
                Bind<ITagsService>().ToConstant(_tagServiceMock.Object);

            if(_unitOfWorkMock != null)
                Bind<IUnitOfWork>().ToConstant(_unitOfWorkMock.Object);

            
        }
    }
}
