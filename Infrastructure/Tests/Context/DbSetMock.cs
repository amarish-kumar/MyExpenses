/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests.Context
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using Moq;

    using MyExpenses.Domain.Interfaces;

    internal static class DbSetMock
    {
        /// <summary>
        /// Create DbSet mock
        /// </summary>
        /// <typeparam name="TDomain" cref="IDomain">Domain abstration</typeparam>
        /// <param name="objs">Collection of domains</param>
        /// <returns>DbSet mock</returns>
        public static Mock<DbSet<TDomain>> CreateMock<TDomain>(ICollection<TDomain> objs) where TDomain : class, IDomain
        {
            ObservableCollection<TDomain> list = new ObservableCollection<TDomain>(objs);

            IQueryable<TDomain> queryable = list.AsQueryable();
            Mock<DbSet<TDomain>> mockList = new Mock<DbSet<TDomain>>(MockBehavior.Loose);

            mockList.As<IQueryable<TDomain>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockList.As<IQueryable<TDomain>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockList.As<IQueryable<TDomain>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockList.As<IQueryable<TDomain>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockList.Setup(m => m.Include(It.IsAny<string>())).Returns(mockList.Object);
            mockList.Setup(m => m.Local).Returns(list);
            mockList.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] a) => { return (TDomain)list.FirstOrDefault<TDomain>(x => x.Id == int.Parse(a[0].ToString())); });
            mockList.Setup(m => m.Add(It.IsAny<TDomain>())).Returns((TDomain a) => { list.Add(a); return a; });
            mockList.Setup(m => m.AddRange(It.IsAny<IEnumerable<TDomain>>())).Returns((IEnumerable<TDomain> a) => { foreach (var item in a.ToArray()) list.Add(item); return a; });
            mockList.Setup(m => m.Remove(It.IsAny<TDomain>())).Returns((TDomain a) => { list.Remove(a); return a; });
            mockList.Setup(m => m.RemoveRange(It.IsAny<IEnumerable<TDomain>>())).Returns((IEnumerable<TDomain> a) => { foreach (var item in a.ToArray()) list.Remove(item); return a; });

            return mockList;
        }
    }
}
