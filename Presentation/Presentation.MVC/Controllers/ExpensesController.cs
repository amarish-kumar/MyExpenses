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
        public IActionResult Index()
        {
            var presentationMVCContext = _context.Expenses.Include(e => e.Tag);
            return View(presentationMVCContext.ToList());
        }

        // GET: Expenses/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _context.Expenses
                .Include(e => e.Tag)
                .SingleOrDefault(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewData["TagId"] = new SelectList(_context.Set<Tag>(), "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Value,Date,TagId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TagId"] = new SelectList(_context.Set<Tag>(), "Id", "Name", expense.TagId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _context.Expenses.SingleOrDefault(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["TagId"] = new SelectList(_context.Set<Tag>(), "Id", "Name", expense.TagId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,Value,Date,TagId")] Expense expense)
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
                    _context.SaveChanges();
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
            ViewData["TagId"] = new SelectList(_context.Set<Tag>(), "Id", "Name", expense.TagId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _context.Expenses
                .Include(e => e.Tag)
                .SingleOrDefault(m => m.Id == id);
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
            var expense = _context.Expenses.SingleOrDefault(m => m.Id == id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(long id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
