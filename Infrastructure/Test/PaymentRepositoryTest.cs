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
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;

    [TestClass]
    public class PaymentRepositoryTest : RepositoryTestBase<Payment, IPaymentRepository>
    {
        [TestInitialize]
        public void Initialize()
        {
            Repository = GetAppService<IPaymentRepository>();
            UnitOfWork = GetAppService<IUnitOfWork>();
            ModelBase = new Payment { Name = "Test" };
        }

        [TestMethod]
        public void PaymentTestInclude()
        {
            // arrange

            // act
            var allObjs = Repository.Get(x => x.Expenses).ToList();

            // assert
            Assert.IsTrue(allObjs.Any());
            allObjs.ForEach(x => { Assert.IsTrue(x.Expenses.Any()); });
        }

        [TestMethod]
        public void PaymentTestGetByIdWithInclude()
        {
            // arrange

            // act
            var obj = Repository.GetById(1, x => x.Expenses);

            // assert
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Expenses);
            Assert.IsTrue(obj.Expenses.Any());
        }
    }
}