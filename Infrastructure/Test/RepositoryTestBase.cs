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
        InfrastructureTestBase where TModel : IModel where TRepository : IService<TModel>
    {
        protected TRepository Repository;
        protected IUnitOfWork UnitOfWork;

        [TestCleanup]
        public void CleanUp()
        {
            Repository = default(TRepository);
            UnitOfWork = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            var all = Repository.Get();

            Assert.IsTrue(all.Any());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        public void RemoveAValidObject(long id)
        {
            UnitOfWork.BeginTransaction();
            bool removed = Repository.Remove(id);
            if (removed)
                UnitOfWork.Commit();

            Assert.IsTrue(removed);
            Assert.IsNull(Repository.GetById(id));
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void RemoveAnInvalidObject(long id)
        {
            UnitOfWork.BeginTransaction();
            bool removed = Repository.Remove(id);
            if (removed)
                UnitOfWork.Commit();

            Assert.IsFalse(removed);
            Assert.IsNull(Repository.GetById(id));
        }
    }
}