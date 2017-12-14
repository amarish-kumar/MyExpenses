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
    public class ExpenseStatusController : Controller
    {
        private readonly PresentationMVCContext _context;

        public ExpenseStatusController(PresentationMVCContext context)
        {
            _context = context;
        }

        // GET: ExpenseStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseStatus.ToListAsync());
        }

        // GET: ExpenseStatus/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseStatus = await _context.ExpenseStatus
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseStatus == null)
            {
                return NotFound();
            }

            return View(expenseStatus);
        }

        // GET: ExpenseStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ExpenseStatus expenseStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseStatus);
        }

        // GET: ExpenseStatus/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseStatus = await _context.ExpenseStatus.SingleOrDefaultAsync(m => m.Id == id);
            if (expenseStatus == null)
            {
                return NotFound();
            }
            return View(expenseStatus);
        }

        // POST: ExpenseStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] ExpenseStatus expenseStatus)
        {
            if (id != expenseStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseStatusExists(expenseStatus.Id))
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
            return View(expenseStatus);
        }

        // GET: ExpenseStatus/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseStatus = await _context.ExpenseStatus
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseStatus == null)
            {
                return NotFound();
            }

            return View(expenseStatus);
        }

        // POST: ExpenseStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var expenseStatus = await _context.ExpenseStatus.SingleOrDefaultAsync(m => m.Id == id);
            _context.ExpenseStatus.Remove(expenseStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseStatusExists(long id)
        {
            return _context.ExpenseStatus.Any(e => e.Id == id);
        }
    }
}
