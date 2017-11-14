/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;

    using Moq;

    using MyExpenses.Domain.Interfaces;

    internal static class DbSetMock
    {
        public static Mock<DbSet<T>> GetMock<T>(ObservableCollection<T> list) where T : class, IDomain
        {
            IQueryable<T> queryable = list.AsQueryable();
            Mock<DbSet<T>> mockList = new Mock<DbSet<T>>(MockBehavior.Loose);

            mockList.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockList.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockList.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockList.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockList.Setup(m => m.Include(It.IsAny<string>())).Returns(mockList.Object);
            mockList.Setup(m => m.Local).Returns(list);
            mockList.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] a) => { return (T)list.FirstOrDefault<IDomain>(x => x.Id == int.Parse(a[0].ToString())); });
            mockList.Setup(m => m.Add(It.IsAny<T>())).Returns((T a) => { list.Add(a); return a; });
            mockList.Setup(m => m.AddRange(It.IsAny<IEnumerable<T>>())).Returns((IEnumerable<T> a) => { foreach (var item in a.ToArray()) list.Add(item); return a; });
            mockList.Setup(m => m.Remove(It.IsAny<T>())).Returns((T a) => { list.Remove(a); return a; });
            mockList.Setup(m => m.RemoveRange(It.IsAny<IEnumerable<T>>())).Returns((IEnumerable<T> a) => { foreach (var item in a.ToArray()) list.Remove(item); return a; });

            return mockList;
        }
    }
}
