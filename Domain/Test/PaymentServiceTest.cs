/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.DomainTest
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using MyExpenses.Domain.Interfaces.Services;

    [TestClass]
    public class PaymentServiceTest : DomainTestBase
    {
        private IPaymentService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = GetAppService<IPaymentService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _service = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            var all = _service.Get();

            Assert.IsTrue(all.Any());
        }
    }
}