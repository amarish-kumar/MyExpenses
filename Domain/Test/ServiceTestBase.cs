/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.DomainTest
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Domain.Interfaces;

    public abstract class ServiceTestBase<TModel, TService> : DomainTestBase
        where TModel : class, IModel where TService : IService<TModel>
    {
        protected TService Service;
        protected IUnitOfWork UnitOfWork;
        protected TModel ModelBase;

        [TestCleanup]
        public void CleanUp()
        {
            Service = default(TService);
            UnitOfWork = null;
            ModelBase = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            // arrange

            // act
            var all = Service.Get();

            // assert
            Assert.IsTrue(all.Any());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(9)]
        public void RemoveValidObject(long id)
        {
            // arrange

            // act
            UnitOfWork.BeginTransaction();
            bool removed = Service.Remove(id);
            UnitOfWork.Commit();

            // assert
            Assert.IsTrue(removed);
            Assert.IsNull(Service.GetById(id));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(9)]
        public void UpdateValidObject(long id)
        {
            // act
            ModelBase.Id = id;

            // arrange
            UnitOfWork.BeginTransaction();
            var obj = Service.Update(ModelBase);
            UnitOfWork.Commit();

            // assert
            Assert.IsNotNull(obj);
            Assert.IsNotNull(Service.GetById(id));
        }
    }
}
