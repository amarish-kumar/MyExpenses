/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.InfrastructureTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;

    [TestClass]
    public class LabelRepositoryTest : RepositoryTestBase<Label, ILabelRepository>
    {
        [TestInitialize]
        public void Initialize()
        {
            Repository = GetAppService<ILabelRepository>();
            UnitOfWork = GetAppService<IUnitOfWork>();
        }

        [TestMethod]
        public void Dummy()
        {
            // just to avoid warning
            Assert.IsTrue(true);
        }
    }
}