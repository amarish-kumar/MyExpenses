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
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.WebApplicationMVC.Models;

    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _service;
        private readonly ILabelRepository _labelRepository;
        private readonly IPaymentRepository _paymentRepository;

        public ExpensesController(
            IExpenseAppService service,
            ILabelRepository labelRepository,
            IPaymentRepository paymentRepository)
        {
            _service = service;

            _labelRepository = labelRepository;
            _paymentRepository = paymentRepository;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetAllAsync(x => x.Label, x => x.Payment);

            ExpenseViewModel viewModel = new ExpenseViewModel
            {
                Incoming = expenses.Where(x => x.IsIncoming).ToList(),
                Outcoming = expenses.Where(x => !x.IsIncoming).ToList(),
                TotalIncoming = expenses.Where(x => x.IsIncoming).Sum(x => x.Value),
                TotalOutcoming = expenses.Where(x => !x.IsIncoming).Sum(x => x.Value)
            };
            viewModel.TotalLeft = viewModel.TotalIncoming - viewModel.TotalOutcoming;

            return View(viewModel);
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _service.GetByIdAsync(id.Value, x => x.Label, x => x.Payment);

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

            return View(new Expense { Data = DateTime.Today });
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            { 
                await _service.AddOrUpdateAsync(expense);
                return RedirectToAction(nameof(Index));
            }

            CreateSelectLists(expense.LabelId, expense.PaymentId);

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _service.GetByIdAsync(id.Value, x => x.Label, x => x.Payment);

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
        public async Task<IActionResult> Edit(long id, Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddOrUpdateAsync(expense);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ExpenseExists(expense.Id))
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
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _service.GetByIdAsync(id.Value, x => x.Label, x => x.Payment);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var expense = await _service.GetByIdAsync(id, x => x.Label, x => x.Payment);
            await _service.RemoveAsync(expense);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ExpenseExists(long id)
        {
            var expense = await _service.GetByIdAsync(id);
            return expense != null;
        }

        private async void CreateSelectLists(long? labelId = null, long? paymentId = null)
        {
            IEnumerable<Label> lables = await _labelRepository.GetAllAsync();
            IEnumerable<Payment> payments = await _paymentRepository.GetAllAsync();
            ViewData["Labels"] = new SelectList(lables, "Id", "Name", labelId);
            ViewData["Payments"] = new SelectList(payments, "Id", "Name", paymentId);
        }
    }
}
