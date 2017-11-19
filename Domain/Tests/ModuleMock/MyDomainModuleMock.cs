/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.ModulesMock
{
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;

    using Ninject.Modules;
    using MyExpenses.Infrastructure.Tests.Context;
    using MyExpenses.Util.Logger;
    using MyExpenses.Domain.Services;
    using System;

    public class MyDomainModuleMock : NinjectModule
    {
        private readonly IMyContext _contextMock;

        public MyDomainModuleMock()
        {

            ICollection<Tag> tags = new List<Tag>
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
                        Value = 2
                    },
                new Expense
                    {
                        Id = 2,
                        Name = "Expense2",
                        Date = new DateTime(),
                        Value = 10
                    },
                new Expense
                    {
                        Id = 3,
                        Name = "Expense3",
                        Date = new DateTime(),
                        Value = 15
                    }
            };

            _contextMock = new MyContextMock(expenses, tags);
        }

        public override void Load()
        {
            Bind<IExpensesService>().To<ExpensesService>();
            Bind<ITagsService>().To<TagsService>();

            Bind<IExpensesRepository>().To<ExpensesRepository>();
            Bind<ITagsRepository>().To<TagsRepository>();

            Bind<IMyContext>().ToConstant(_contextMock);

            Bind<ILogService>().To<LogService>();
        }
    }
}
