/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.ModulesMock
{
    using Microsoft.EntityFrameworkCore;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Util.IoC;
    using Ninject.Modules;
    using System;
    using System.Collections.Generic;

    public class MyApplicationModuleMock : NinjectModule
    {
        private readonly IMyContext _context;

        public MyApplicationModuleMock()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new MyContext(options);
        }

        public void LoadData()
        {
            List<Tag> tags = new List<Tag>
            {
                new Tag
                {
                    Id = 0,
                    Name = "Tag1"
                },
                new Tag
                {
                    Id = 0,
                    Name = "Tag2"
                },
                new Tag
                {
                    Id = 0,
                    Name = "Tag3"
                }
            };
            List<Expense> expenses = new List<Expense>
            {
                new Expense
                    {
                        Id = 0,
                        Name = "Expense1",
                        Date = new DateTime(),
                        Value = 2,
                        Tag = tags[0]
                    },
                new Expense
                    {
                        Id = 0,
                        Name = "Expense2",
                        Date = new DateTime(),
                        Value = 10,
                        Tag = tags[1]
                    },
                new Expense
                    {
                        Id = 0,
                        Name = "Expense3",
                        Date = new DateTime(),
                        Value = 15,
                        Tag = tags[2]
                    }
            };

            var unitOfWork = MyKernelService.GetInstance<IUnitOfWork>();

            unitOfWork.BeginTransaction();

            // populate
            tags.ForEach(x => _context.Set<Tag>().Add(x));
            expenses.ForEach(x => _context.Set<Expense>().Add(x));

            unitOfWork.Commit();
        }

        public override void Load()
        {
            Rebind<IMyContext>().ToConstant(_context);

            LoadData();
        }
    }
}
