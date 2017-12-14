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
    public class ExpenseHowsController : Controller
    {
        private readonly PresentationMVCContext _context;

        public ExpenseHowsController(PresentationMVCContext context)
        {
            _context = context;
        }

        // GET: ExpenseHows
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseHow.ToListAsync());
        }

        // GET: ExpenseHows/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseHow = await _context.ExpenseHow
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseHow == null)
            {
                return NotFound();
            }

            return View(expenseHow);
        }

        // GET: ExpenseHows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseHows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ExpenseHow expenseHow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseHow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseHow);
        }

        // GET: ExpenseHows/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseHow = await _context.ExpenseHow.SingleOrDefaultAsync(m => m.Id == id);
            if (expenseHow == null)
            {
                return NotFound();
            }
            return View(expenseHow);
        }

        // POST: ExpenseHows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] ExpenseHow expenseHow)
        {
            if (id != expenseHow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseHow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseHowExists(expenseHow.Id))
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
            return View(expenseHow);
        }

        // GET: ExpenseHows/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseHow = await _context.ExpenseHow
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseHow == null)
            {
                return NotFound();
            }

            return View(expenseHow);
        }

        // POST: ExpenseHows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var expenseHow = await _context.ExpenseHow.SingleOrDefaultAsync(m => m.Id == id);
            _context.ExpenseHow.Remove(expenseHow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseHowExists(long id)
        {
            return _context.ExpenseHow.Any(e => e.Id == id);
        }
    }
}
