/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.ModulesMock
{
    using Microsoft.EntityFrameworkCore;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using Ninject.Modules;
    using System;
    using System.Collections.Generic;

    public class MyApplicationModuleMock : NinjectModule
    {
        private readonly IMyContext _context;

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
            List<Expense> expenses = new List<Expense>
            {
                new Expense
                    {
                        Id = 1,
                        Name = "Expense1",
                        Date = new DateTime(),
                        Value = 2,
                        Tag = tags[0]
                    },
                new Expense
                    {
                        Id = 2,
                        Name = "Expense2",
                        Date = new DateTime(),
                        Value = 10,
                        Tag = tags[1]
                    },
                new Expense
                    {
                        Id = 3,
                        Name = "Expense3",
                        Date = new DateTime(),
                        Value = 15,
                        Tag = tags[2]
                    }
            };

            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new MyContext(options);

            // populate
            expenses.ForEach(x => _context.Expenses.Add(x));
            tags.ForEach(x => _context.Tags.Add(x));
        }

        public override void Load()
        {
            Rebind<IMyContext>().ToConstant(_context);
        }
    }
}
