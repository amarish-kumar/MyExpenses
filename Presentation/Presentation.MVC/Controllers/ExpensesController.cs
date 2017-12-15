using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.MVC.Models;

namespace Presentation.MVC.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly PresentationMVCContext _context;

        public ExpensesController(PresentationMVCContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var presentationMVCContext = _context.Expenses.Include(e => e.ExpenseHow).Include(e => e.ExpenseStatus).Include(e => e.ExpenseTag);
            return View(await presentationMVCContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.ExpenseHow)
                .Include(e => e.ExpenseStatus)
                .Include(e => e.ExpenseTag)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewData["ExpenseHowId"] = new SelectList(_context.ExpenseHow, "Id", "Name");
            ViewData["ExpenseStatusId"] = new SelectList(_context.ExpenseStatus, "Id", "Name");
            ViewData["ExpenseTagId"] = new SelectList(_context.ExpenseTag, "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value,Date,IsIncome,SplitAmount,ExpenseTagId,ExpenseHowId,ExpenseStatusId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpenseHowId"] = new SelectList(_context.ExpenseHow, "Id", "Name", expense.ExpenseHowId);
            ViewData["ExpenseStatusId"] = new SelectList(_context.ExpenseStatus, "Id", "Name", expense.ExpenseStatusId);
            ViewData["ExpenseTagId"] = new SelectList(_context.ExpenseTag, "Id", "Name", expense.ExpenseTagId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.SingleOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ExpenseHowId"] = new SelectList(_context.ExpenseHow, "Id", "Name", expense.ExpenseHowId);
            ViewData["ExpenseStatusId"] = new SelectList(_context.ExpenseStatus, "Id", "Name", expense.ExpenseStatusId);
            ViewData["ExpenseTagId"] = new SelectList(_context.ExpenseTag, "Id", "Name", expense.ExpenseTagId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Value,Date,IsIncome,SplitAmount,ExpenseTagId,ExpenseHowId,ExpenseStatusId")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
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
            ViewData["ExpenseHowId"] = new SelectList(_context.ExpenseHow, "Id", "Name", expense.ExpenseHowId);
            ViewData["ExpenseStatusId"] = new SelectList(_context.ExpenseStatus, "Id", "Name", expense.ExpenseStatusId);
            ViewData["ExpenseTagId"] = new SelectList(_context.ExpenseTag, "Id", "Name", expense.ExpenseTagId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.ExpenseHow)
                .Include(e => e.ExpenseStatus)
                .Include(e => e.ExpenseTag)
                .SingleOrDefaultAsync(m => m.Id == id);
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
            var expense = await _context.Expenses.SingleOrDefaultAsync(m => m.Id == id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(long id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
