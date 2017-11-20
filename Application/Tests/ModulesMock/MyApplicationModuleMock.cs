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
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Services;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.Tests.Context;
    using MyExpenses.Util.Logger;
    using Ninject.Modules;
    using System;
    using System.Collections.Generic;

    public class MyApplicationModuleMock : NinjectModule
    {
        private readonly IMyContext _contextMock;

        public MyApplicationModuleMock()
        {

            List<Tag> tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "Tag1"
                },
                new Tag
                {
                    Id = 2,
                    Name = "Tag2"
                },
                new Tag
                {
                    Id = 3,
                    Name = "Tag3"
                }
            };
            ICollection<Expense> expenses = new List<Expense>
            {
                new Expense
                    {
                        Id = 1,
                        Name = "Expense1",
                        Date = new DateTime(),
                        Value = 2,
                        Tags = new List<Tag> { tags[0] }
                    },
                new Expense
                    {
                        Id = 2,
                        Name = "Expense2",
                        Date = new DateTime(),
                        Value = 10,
                        Tags = new List<Tag> { tags[1] }
                    },
                new Expense
                    {
                        Id = 3,
                        Name = "Expense3",
                        Date = new DateTime(),
                        Value = 15,
                        Tags = new List<Tag> { tags[2] }
                    }
            };

            _contextMock = new MyContextMock(expenses, tags);
        }

        public override void Load()
        {
            Bind<IExpensesAppService>().To<ExpensesAppService>();
            Bind<ITagsAppService>().To<TagsAppService>();

            Bind<IExpensesAdapter>().To<ExpensesAdapter>();
            Bind<ITagsAdapter>().To<TagsAdapter>();

            Bind<IExpensesService>().To<ExpensesService>();
            Bind<ITagsService>().To<TagsService>();

            Bind<IExpensesRepository>().To<ExpensesRepository>();
            Bind<ITagsRepository>().To<TagsRepository>();

            Bind<ILogService>().To<LogService>();

            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(x => x.BeginTransaction());
            unitOfWorkMock.Setup(x => x.Commit());
            Bind<IUnitOfWork>().ToConstant(unitOfWorkMock.Object);

            Bind<IMyContext>().ToConstant(_contextMock);
        }
    }
}
