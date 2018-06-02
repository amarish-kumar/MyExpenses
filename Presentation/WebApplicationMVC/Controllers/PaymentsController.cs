/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Dtos;
    using MyExpenses.WebApplicationMVC.Models;
    using MyExpenses.WebApplicationMVC.Properties;

    public class PaymentsController : Controller
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly IPaymentAppService _appService;

        public PaymentsController(IPaymentAppService paymentAppService, IExpenseAppService expenseAppService)
        {
            _appService = paymentAppService;
            _expenseAppService = expenseAppService;
        }

        // GET: Payments
        public IActionResult Index(int month, int year)
        {
            DateTime startDateTime = Util.MyDate.GetStartDateTime(month, year);
            DateTime endDateTime = Util.MyDate.GetEndDateTime(month, year);

            PaymentIndexViewModel viewModel = new PaymentIndexViewModel
            {
                Payments = _appService.Get(startDateTime, endDateTime).ToList(),
                Month = startDateTime.Month,
                Year = startDateTime.Year
            };

            CreateDateLists(startDateTime.Month, startDateTime.Year);

            return View(viewModel);
        }

        // GET: Payments/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _appService.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id")] PaymentDto payment)
        {
            if (ModelState.IsValid)
            {
                _appService.AddOrUpdate(payment);
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _appService.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Name,Id")] PaymentDto payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appService.AddOrUpdate(payment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
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
            return View(payment);
        }

        // GET: Payments/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _appService.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _appService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(long id)
        {
            return _appService.GetById(id) != null;
        }

        private void CreateDateLists(int selectedMonth, int selectedYear)
        {
            ViewData[Resource.MonthsViewData] = MonthViewModel.GetAll(selectedMonth);
            ViewData[Resource.YearsViewData] = new SelectList(_expenseAppService.GetAllYears(), selectedYear);
        }
    }
}
