/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.ApplicationTest
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Application.Interfaces.Services;

    [TestClass]
    public class ServicesTest : AppServicesTestBase
    {
        private IExpenseAppService _expenseAppService;
        private ILabelAppService _labelAppService;
        private IPaymentAppService _paymentAppService;

        [TestInitialize]
        public void Initialize()
        {
            Init();
            Fill();

            _expenseAppService = GetAppService<IExpenseAppService>();
            _labelAppService = GetAppService<ILabelAppService>();
            _paymentAppService = GetAppService<IPaymentAppService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Clean();

            _expenseAppService = null;
            _labelAppService = null;
            _paymentAppService = null;
        }

        [TestMethod]
        public void AppServiceTestInitAndFill()
        {
            var allExpenses = _expenseAppService.GetAll();
            var allLabels = _labelAppService.GetAll();
            var allPayments = _paymentAppService.GetAll();

            Assert.IsTrue(allExpenses.Any());
            Assert.IsTrue(allLabels.Any());
            Assert.IsTrue(allPayments.Any());
        }

        [TestMethod]
        public void AppServiceTestPogValue()
        {
            var allExpenses = _expenseAppService.GetAll().ToList();

            allExpenses.ForEach(x => Assert.AreEqual(x.Value * 100, x.ValuePog));
        }

        [TestMethod]
        public void AppServiceTestRemoveAll()
        {
            _labelAppService.GetAll().ToList().ForEach(x => _labelAppService.Remove(x.Id));
            _paymentAppService.GetAll().ToList().ForEach(x => _paymentAppService.Remove(x.Id));
            _expenseAppService.GetAll().ToList().ForEach(x => _expenseAppService.Remove(x.Id));
            
            Assert.IsFalse(_labelAppService.GetAll().Any());
            Assert.IsFalse(_paymentAppService.GetAll().Any());
            Assert.IsFalse(_expenseAppService.GetAll().Any());
        }

        [TestMethod]
        public void AppServiceTestIncludeLabelAndPayment()
        {
            const int ID = 3;

            var expense = _expenseAppService.GetById(ID);
            
            Assert.IsNotNull(expense.Label);
            Assert.IsNotNull(expense.Payment);
        }

        [TestMethod]
        public void AppServiceTestRemoveLabelFromExpense()
        {
            const int ID = 3;

            Assert.IsTrue(_expenseAppService.GetAll().Any(x => x.LabelId == ID));

            Assert.IsTrue(_labelAppService.Remove(ID));
            Assert.IsNull(_labelAppService.GetById(ID));

            Assert.IsFalse(_expenseAppService.GetAll().Any(x => x.LabelId == ID));
        }

        [TestMethod]
        public void AppServiceTestRemovePaymentFromExpense()
        {
            const int ID = 3;

            Assert.IsTrue(_expenseAppService.GetAll().Any(x => x.PaymentId == ID));

            Assert.IsTrue(_paymentAppService.Remove(ID));
            Assert.IsNull(_paymentAppService.GetById(ID));

            Assert.IsFalse(_expenseAppService.GetAll().Any(x => x.PaymentId == ID));
        }

        [TestMethod]
        public void AppServiceTestAllYears()
        {
            var allYears = _expenseAppService.GetAllYears().ToList();

            Assert.IsTrue(allYears.Any());
            Assert.AreEqual(1, allYears.Count);
        }

        [TestMethod]
        public void AppServiceTestIncomingAndOutcomingExpensesToday()
        {
            var today = DateTime.Today;

            var start = Util.MyDate.GetStartDateTime(today);
            var end = Util.MyDate.GetEndDateTime(today);

            var incoming = _expenseAppService.GetAllIncoming(start, end).ToList();
            var outcoming = _expenseAppService.GetAllOutcoming(start, end).ToList();

            Assert.IsTrue(incoming.Any());
            Assert.IsTrue(incoming.All(x => x.IsIncoming));

            Assert.IsTrue(outcoming.Any());
            Assert.IsTrue(outcoming.All(x => !x.IsIncoming));
        }

        [TestMethod]
        public void AppServiceTestIncomingAndOutcomingExpensesYesterday()
        {
            var yesterday = DateTime.Today.AddMonths(-1);

            var start = Util.MyDate.GetStartDateTime(yesterday);
            var end = Util.MyDate.GetEndDateTime(yesterday);

            var incoming = _expenseAppService.GetAllIncoming(start, end).ToList();
            var outcoming = _expenseAppService.GetAllOutcoming(start, end).ToList();

            Assert.IsFalse(incoming.Any());
            Assert.IsFalse(outcoming.Any());
        }

        [TestMethod]
        public void AppServiceTestGetAllLabelsToday()
        {
            var today = DateTime.Today;

            var start = Util.MyDate.GetStartDateTime(today);
            var end = Util.MyDate.GetEndDateTime(today);

            var labels = _labelAppService.GetAll(start, end).ToList();

            Assert.IsTrue(labels.Any());
            Assert.IsTrue(labels.All(x => x.QuantityOfExpenses > 0));
            Assert.IsTrue(labels.All(x => x.Value > 0));
        }

        [TestMethod]
        public void AppServiceTestGetAllLabelsYesterday()
        {
            var yesterday = DateTime.Today.AddMonths(-1);

            var start = Util.MyDate.GetStartDateTime(yesterday);
            var end = Util.MyDate.GetEndDateTime(yesterday);

            var labels = _labelAppService.GetAll(start, end).ToList();

            Assert.IsTrue(labels.Any());
            Assert.IsFalse(labels.All(x => x.QuantityOfExpenses > 0));
            Assert.IsFalse(labels.All(x => x.Value > 0));
        }

        [TestMethod]
        public void AppServiceTestGetAllPaymentsToday()
        {
            var today = DateTime.Today;

            var start = Util.MyDate.GetStartDateTime(today);
            var end = Util.MyDate.GetEndDateTime(today);

            var payments = _paymentAppService.GetAll(start, end).ToList();

            Assert.IsTrue(payments.Any());
            Assert.IsTrue(payments.All(x => x.QuantityOfExpenses > 0));
            Assert.IsTrue(payments.All(x => x.Value > 0));
        }

        [TestMethod]
        public void AppServiceTestGetAllPaymentsYesterday()
        {
            var yesterday = DateTime.Today.AddMonths(-1);

            var start = Util.MyDate.GetStartDateTime(yesterday);
            var end = Util.MyDate.GetEndDateTime(yesterday);

            var payments = _paymentAppService.GetAll(start, end).ToList();

            Assert.IsTrue(payments.Any());
            Assert.IsFalse(payments.All(x => x.QuantityOfExpenses > 0));
            Assert.IsFalse(payments.All(x => x.Value > 0));
        }
    }
}
