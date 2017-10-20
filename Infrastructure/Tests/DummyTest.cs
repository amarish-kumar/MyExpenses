/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Moq;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Repositories;

    using NUnit.Framework;

    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void DummyTestWhenIsTrue()
        {
            DbSet<Expense> dtset = GetQueryableMockDbSet(
                new List<Expense>
                    {
                        new Expense
                            {
                                Id = 1,
                                Name = "Expense1",
                                Value = 2,
                                Date = new DateTime()
                            }
                    });

            Mock<IMyContext> context = new Mock<IMyContext>(MockBehavior.Strict);
            context.Setup(x => x.Set<Expense>()).Returns(dtset);

            IExpensesRepo expenseRepo = new ExpensesRepo(context.Object);

            Assert.True(expenseRepo.GetAll().Any());
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(ICollection<T> sourceList) where T : class
        {
            IQueryable<T> queryable = sourceList.AsQueryable();

            Mock<DbSet<T>> dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }
}
