/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
        private Mock<IMyContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            ObservableCollection<Expense> expensesOb = new ObservableCollection<Expense>
                                                         {
                                                             new Expense { Id = 1, Name = "Expense1", Value = 2, Date = new DateTime(), Tags = new List<Tag>() }
                                                         };
            List<Expense> expenses = new List<Expense> { new Expense { Id = 1, Name = "Expense1", Value = 2, Date = new DateTime(), Tags = new List<Tag>() } };
            DbSet<Expense> dtset = GetQueryableMockDbSet(expenses);

            //dtset.Include(x => x.Tags);

            Mock<DbSet<Expense>> moq = GetMockSet<Expense>(expensesOb);

            _contextMock = new Mock<IMyContext>(MockBehavior.Strict);
            _contextMock.Setup(x => x.Set<Expense>()).Returns(moq.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _contextMock = null;
        }

        [Test]
        public void TestGetAllExpenses()
        {
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

            Assert.True(expenseRepo.GetAll(x => x.Tags).Any());
        }


        [Test]
        public void TestGetExpenses()
        {
            IExpensesRepo expenseRepo = new ExpensesRepo(_contextMock.Object);

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

        public static Mock<DbSet<T>> GetMockSet<T>(ObservableCollection<T> list) where T : class
        {
            var queryable = list.AsQueryable();
            var mockList = new Mock<DbSet<T>>(MockBehavior.Loose);

            mockList.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockList.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockList.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockList.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockList.Setup(m => m.Include(It.IsAny<string>())).Returns(mockList.Object);
            mockList.Setup(m => m.Local).Returns(list);
            mockList.Setup(m => m.Add(It.IsAny<T>())).Returns((T a) => { list.Add(a); return a; });
            mockList.Setup(m => m.AddRange(It.IsAny<IEnumerable<T>>())).Returns((IEnumerable<T> a) => { foreach (var item in a.ToArray()) list.Add(item); return a; });
            mockList.Setup(m => m.Remove(It.IsAny<T>())).Returns((T a) => { list.Remove(a); return a; });
            mockList.Setup(m => m.RemoveRange(It.IsAny<IEnumerable<T>>())).Returns((IEnumerable<T> a) => { foreach (var item in a.ToArray()) list.Remove(item); return a; });

            return mockList;
        }
    }
}
