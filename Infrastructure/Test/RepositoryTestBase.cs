/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.InfrastructureTest
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Domain.Interfaces;

    public abstract class RepositoryTestBase<TModel, TRepository> :
        InfrastructureTestBase where TModel : class, IModel where TRepository : IService<TModel>
    {
        protected TRepository Repository;
        protected IUnitOfWork UnitOfWork;
        protected TModel ModelBase;

        [TestCleanup]
        public void CleanUp()
        {
            Repository = default(TRepository);
            UnitOfWork = null;
            ModelBase = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            // arrange

            // act
            var all = Repository.Get();

            // assert
            Assert.IsTrue(all.Any());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        public void RemoveValidObject(long id)
        {
            // arrange

            // act
            UnitOfWork.BeginTransaction();
            bool removed = Repository.Remove(id);
            UnitOfWork.Commit();

            // assert
            Assert.IsTrue(removed);
            Assert.IsNull(Repository.GetById(id));
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void RemoveInvalidObject(long id)
        {
            // arrange

            // act
            bool removed = Repository.Remove(id);

            // assert
            Assert.IsFalse(removed);
            Assert.IsNull(Repository.GetById(id));
        }

        [TestMethod]
        public void UpdateNullObject()
        {
            // arrage

            // act
            var obj = Repository.Update(null);

            // assert
            Assert.IsNull(obj);
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void UpdateInvalidObject(long id)
        {
            // act
            ModelBase.Id = id;

            // arrange
            var obj = Repository.Update(ModelBase);

            // assert
            Assert.IsNull(obj);
            Assert.IsNull(Repository.GetById(id));
        }

        [TestMethod]
        public void AddNullObject()
        {
            // act

            // arrange
            var obj = Repository.Add(null);

            // assert
            Assert.IsNull(obj);
        }

        [TestMethod]
        public void AddValidObject()
        {
            // arrange
            var allObjs = Repository.Get();
            var first = allObjs.First();
            var numberOfObjs = allObjs.Count();

            ModelBase.Copy(first);
            ModelBase.Id = 0;
            
            // act
            UnitOfWork.BeginTransaction();
            Repository.Add(ModelBase);
            UnitOfWork.Commit();

            // assert
            Assert.AreNotEqual(numberOfObjs, Repository.Get().Count());
        }
    }
}