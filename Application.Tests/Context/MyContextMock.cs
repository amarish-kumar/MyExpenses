/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Context
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Moq;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    internal class MyContextMock : IMyContext
    {
        private readonly Mock<IMyContext> _contextMock;

        public MyContextMock(ICollection<Expense> expenses, ICollection<Tag> tags)
        {
            //Expenses = new TestDbSet<Expense>();
            //Tags = new TestDbSet<Tag>();

            expenses.ToList().ForEach(x => Expenses.Add(x));
            tags.ToList().ForEach(x => Tags.Add(x));

            _contextMock = new Mock<IMyContext>(MockBehavior.Strict);
            _contextMock.Setup(x => x.Set<Expense>()).Returns(Expenses);
            _contextMock.Setup(x => x.Set<Tag>()).Returns(Tags);
            _contextMock.Setup(x => x.SaveChanges()).Returns(1);
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public int SaveChanges()
        {
            return _contextMock.Object.SaveChanges();
        }

        public DbSet<TDomain> Set<TDomain>() where TDomain : class
        {
            return _contextMock.Object.Set<TDomain>();
        }   
    }

    //internal class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IAsyncEnumerable<TEntity>
    //    where TEntity : class, IDomain
    //{

    //}

    ///// <summary>
    //    /// Used as reference https://msdn.microsoft.com/en-us/data/dn314431.aspx#doubles
    //    /// </summary>
    //    /// <typeparam name="TEntity">Domain entity</typeparam>
    //    internal class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IAsyncEnumerable<TEntity>
    //    where TEntity : class, IDomain
    //{
    //    private readonly ObservableCollection<TEntity> _data;
    //    private readonly IQueryable _query;

    //    public TestDbSet()
    //    {
    //        _data = new ObservableCollection<TEntity>();
    //        _query = _data.AsQueryable();
    //    }

    //    public override TEntity Add(TEntity entity)
    //    {
    //        _data.Add(entity);
    //        return entity;
    //    }

    //    public override TEntity Remove(TEntity entity)
    //    {
    //        _data.Remove(entity);
    //        return entity;
    //    }

    //    public override TEntity Attach(TEntity entity)
    //    {
    //        return Add(entity);
    //    }

    //    public override TEntity Find(params object[] keyValues)
    //    {
    //        return _data.FirstOrDefault(x => x.Id == int.Parse(keyValues[0].ToString()));
    //    }

    //    public override TEntity Create() => Activator.CreateInstance<TEntity>();

    //    public override TDerivedEntity Create<TDerivedEntity>() => Activator.CreateInstance<TDerivedEntity>();

    //    public override ObservableCollection<TEntity> Local => _data;

    //    Type IQueryable.ElementType => _query.ElementType;

    //    Expression IQueryable.Expression => _query.Expression;

    //    //IQueryProvider IQueryable.Provider => new TestDbAsyncQueryProvider<TEntity>(_query.Provider);

    //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _data.GetEnumerator();

    //    IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => _data.GetEnumerator();

    //    //IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator() => new TestDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
    //}

    //internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    //{
    //    private readonly IQueryProvider _inner;

    //    internal TestDbAsyncQueryProvider(IQueryProvider inner)
    //    {
    //        _inner = inner;
    //    }

    //    public IQueryable CreateQuery(Expression expression)
    //    {
    //        return new TestDbAsyncEnumerable<TEntity>(expression);
    //    }

    //    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    //    {
    //        return new TestDbAsyncEnumerable<TElement>(expression);
    //    }

    //    public object Execute(Expression expression)
    //    {
    //        return _inner.Execute(expression);
    //    }

    //    public TResult Execute<TResult>(Expression expression)
    //    {
    //        return _inner.Execute<TResult>(expression);
    //    }

    //    public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
    //    {
    //        return Task.FromResult(Execute(expression));
    //    }

    //    public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
    //    {
    //        return Task.FromResult(Execute<TResult>(expression));
    //    }
    //}

    //internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    //{
    //    public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
    //        : base(enumerable)
    //    { }

    //    public TestDbAsyncEnumerable(Expression expression)
    //        : base(expression)
    //    { }

    //    public IDbAsyncEnumerator<T> GetAsyncEnumerator() => new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

    //    IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() => GetAsyncEnumerator();

    //    IQueryProvider IQueryable.Provider => new TestDbAsyncQueryProvider<T>(this);
    //}

    //internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    //{
    //    private readonly IEnumerator<T> _inner;

    //    public TestDbAsyncEnumerator(IEnumerator<T> inner)
    //    {
    //        _inner = inner;
    //    }

    //    public void Dispose() => _inner.Dispose();

    //    public Task<bool> MoveNextAsync(CancellationToken cancellationToken) => Task.FromResult(_inner.MoveNext());

    //    public T Current => _inner.Current;

    //    object IDbAsyncEnumerator.Current => Current;
    //}
}
