/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace ApplicationTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyExpenses.Application.Adapters;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Domain.Models;
    using System;

    [TestClass]
    public class AdaptersTest
    {
        private IExpenseAdapter _expenseAdapter;
        private ILabelAdapter _labelAdapter;
        private IPaymentAdapter _paymentAdapter;

        [TestInitialize]
        public void Initialize()
        {
            _labelAdapter = new LabelAdapter();
            _paymentAdapter = new PaymentAdapter();
            _expenseAdapter = new ExpenseAdapter(_labelAdapter, _paymentAdapter);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _labelAdapter = null;
            _paymentAdapter = null;
            _expenseAdapter = null;
        }

        [TestMethod]
        public void AdaptersTest_ModelToDto_WithoutLabelPayment()
        {
            Expense model = new Expense
            {
                Id = 1,
                Name = "ExpenseName",
                Value = 1.1f,
                Data = DateTime.Now,
                IsIncoming = false,
                Label = null,
                LabelId = null,
                Payment = null,
                PaymentId = null
            };

            ExpenseDto dto = _expenseAdapter.ModelToDto(model);

            CompareExpenseModelToDto(model, dto);
        }

        [TestMethod]
        public void AdaptersTest_DtoToModel_WithoutLabelPayment()
        {
            ExpenseDto dto = new ExpenseDto
            {
                Id = 1,
                Name = "ExpenseName",
                Value = 1.1f,
                Data = DateTime.Now,
                IsIncoming = false,
                Label = null,
                LabelId = null,
                Payment = null,
                PaymentId = null
            };

            Expense model = _expenseAdapter.DtoToModel(dto);

            CompareExpenseDtoToModel(dto, model);
        }

        private void CompareExpenseModelToDto(Expense model, ExpenseDto dto)
        {
            Assert.AreEqual(model.Id, dto.Id);
            Assert.AreEqual(model.Name, dto.Name);
            Assert.AreEqual(model.Data, dto.Data);
            Assert.AreEqual(model.IsIncoming, dto.IsIncoming);
            Assert.AreEqual(model.Label, dto.Label);
            Assert.AreEqual(model.LabelId, dto.LabelId);
            Assert.AreEqual(model.Payment, dto.Payment);
            Assert.AreEqual(model.PaymentId, dto.PaymentId);
        }

        private void CompareExpenseDtoToModel(ExpenseDto dto, Expense model)
        {
            Assert.AreEqual(dto.Id, model.Id);
            Assert.AreEqual(dto.Name, model.Name);
            Assert.AreEqual(dto.Data, model.Data);
            Assert.AreEqual(dto.IsIncoming, model.IsIncoming);
            Assert.AreEqual(dto.Label, model.Label);
            Assert.AreEqual(dto.LabelId, model.LabelId);
            Assert.AreEqual(dto.Payment, model.Payment);
            Assert.AreEqual(dto.PaymentId, model.PaymentId);
        }
    }
}
