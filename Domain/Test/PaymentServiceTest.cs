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
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    [TestClass]
    public class PaymentServiceTest : ServiceTestBase<Payment, IPaymentService>
    {
        [TestInitialize]
        public void Initialize()
        {
            Service = GetAppService<IPaymentService>();
            UnitOfWork = GetAppService<IUnitOfWork>();
            ModelBase = new Payment { Name = "Test" };
        }

        [TestMethod]
        public void PaymentTestGetWithInclude()
        {
            // arrange

            // act
            var allObjs = Service.Get(x => x.Expenses).ToList();

            // assert
            Assert.IsTrue(allObjs.Any());
            allObjs.ForEach(x => { Assert.IsTrue(x.Expenses.Any()); });
        }

        [TestMethod]
        public void PaymentTestGetByIdWithInclude()
        {
            // arrange

            // act
            var obj = Service.GetById(1, x => x.Expenses);

            // assert
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Expenses);
            Assert.IsTrue(obj.Expenses.Any());
        }
    }
}