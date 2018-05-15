/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Models;
    using MyExpenses.WebApplicationMVC.Models;
    using MyExpenses.Domain.Interfaces.Services;

    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _service;
        private readonly ILabelService _labelService;
        private readonly IPaymentService _paymentService;

        public ExpensesController(
            IExpenseAppService service,
            ILabelService labelService,
            IPaymentService paymentService)
        {
            _service = service;

            _labelService = labelService;
            _paymentService = paymentService;
        }

        // GET: Expenses
        public IActionResult Index(int month, int year)
        {
            DateTime firstDayOfMonth, lastDayOfMonth;

            if (month <= 0 && year <= 0)
            {
                month = DateTime.Today.Month;
                year = DateTime.Today.Year;
            }

            firstDayOfMonth = new DateTime(year, month, 1);
            lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var allIncoming = _service.GetAllIncoming(firstDayOfMonth, lastDayOfMonth);
            var allOutComing = _service.GetAllOutcoming(firstDayOfMonth, lastDayOfMonth);

            IndexExpenseViewModel viewModel = new IndexExpenseViewModel
            {
                Incoming = allIncoming.ToList(),
                Outcoming = allOutComing.ToList(),
                TotalIncoming = allIncoming.Sum(x => x.Value),
                TotalOutcoming = allOutComing.Sum(x => x.Value),
                Month = firstDayOfMonth.Month,
                Year = firstDayOfMonth.Year
            };
            viewModel.TotalLeft = viewModel.TotalIncoming - viewModel.TotalOutcoming;

            // TODO improve
            var months = _service.GetAll().GroupBy(x => x.Data.Month).OrderBy(x => x.FirstOrDefault().Data.Month).Select(x => x.FirstOrDefault().Data.ToString("MM"));
            var years = _service.GetAll().GroupBy(x => x.Data.Year).Select(x => x.FirstOrDefault().Data.Year);

            ViewData["Months"] = new SelectList(months, viewModel.Month);
            ViewData["Years"] = new SelectList(years, viewModel.Year);

            return View(viewModel);
        }

        // GET: Expenses/052010
        public IActionResult Test(string filter)
        {
            return View();
        }

        // GET: Expenses/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _service.GetById(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            CreateSelectLists();

            return View(new ExpenseDto { Data = DateTime.Today });
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseDto expense)
        {
            if (ModelState.IsValid)
            { 
                _service.AddOrUpdate(expense);
                return RedirectToAction(nameof(Index));
            }

            CreateSelectLists(expense.LabelId, expense.PaymentId);

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _service.GetById(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            CreateSelectLists(expense.LabelId, expense.PaymentId);

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, ExpenseDto expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddOrUpdate(expense);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _service.GetById(id.Value);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(long id)
        {
            return _service.GetById(id) != null;
        }

        private void CreateSelectLists(long? labelId = null, long? paymentId = null)
        {
            IEnumerable<Label> lables = _labelService.GetAll();
            IEnumerable<Payment> payments = _paymentService.GetAll();

            Label[] l = { new Label { Id = -1, Name = string.Empty } };
            lables = lables.Concat(l).OrderBy(x => x.Id);

            Payment[] p = { new Payment { Id = -1, Name = string.Empty } };
            payments = payments.Concat(p).OrderBy(x => x.Id);

            ViewData["Labels"] = new SelectList(lables, "Id", "Name", labelId);
            ViewData["Payments"] = new SelectList(payments, "Id", "Name", paymentId);
        }
    }
}
