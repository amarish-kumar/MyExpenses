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

    public abstract class RepositoryTestBase<TModel, TRepository> : InfrastructureTestBase where TModel : IModel where TRepository : IService<TModel>
    {
        protected TRepository Repository;

        protected IUnitOfWork UnitOfWork;

        [TestMethod]
        public void InitAndFill()
        {
            var all = Repository.Get();

            Assert.IsTrue(all.Any());
        }
    }
}