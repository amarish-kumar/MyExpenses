/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.ModulesMock
{
    using Moq;

    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;

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
            Bind<IExpensesAppService>().To<ExpensesAppService>();
            Bind<ITagsAppService>().To<TagsAppService>();

            Bind<IExpensesAdapter>().To<ExpensesAdapter>();
            Bind<ITagsAdapter>().To<TagsAdapter>();

            if (_expenseServiceMock != null)
                Bind<IExpensesService>().ToConstant(_expenseServiceMock.Object);

            if(_tagServiceMock != null)
                Bind<ITagsService>().ToConstant(_tagServiceMock.Object);

            if(_unitOfWorkMock != null)
                Bind<IUnitOfWork>().ToConstant(_unitOfWorkMock.Object);

            
        }
    }
}
