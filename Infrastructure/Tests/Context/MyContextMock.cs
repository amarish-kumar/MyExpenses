/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Context
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Moq;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;

    public class MyContextMock : IMyContext
    {
        private readonly Mock<IMyContext> _contextMock;

        public MyContextMock(ICollection<Expense> expenses, ICollection<Tag> tags)
        {
            Mock<DbSet<Expense>> expensesMock = DbSetMock.CreateMock(expenses);
            Mock<DbSet<Tag>> tagsMock = DbSetMock.CreateMock(tags);

            _contextMock = new Mock<IMyContext>(MockBehavior.Strict);
            _contextMock.Setup(x => x.Set<Expense>()).Returns(expensesMock.Object);
            _contextMock.Setup(x => x.Set<Tag>()).Returns(tagsMock.Object);
            _contextMock.Setup(x => x.SaveChanges()).Returns(0);
        }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public int SaveChanges()
        {
            return _contextMock.Object.SaveChanges();
        }

        public DbSet<TDomain> Set<TDomain>() where TDomain : class
        {
            return _contextMock.Object.Set<TDomain>();
        }
    }
}
