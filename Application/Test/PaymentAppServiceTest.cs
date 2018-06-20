/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.ApplicationTest
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Application.Interfaces.Services;

    [TestClass]
    public class PaymentAppServiceTest : ApplicationTestBase
    {
        private IPaymentAppService _appService;

        [TestInitialize]
        public void Initialize()
        {
            _appService = GetAppService<IPaymentAppService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _appService = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            var all = _appService.Get();

            Assert.IsTrue(all.Any());
        }
    }
}