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
    public class ExpenseTagsController : Controller
    {
        private readonly PresentationMVCContext _context;

        public ExpenseTagsController(PresentationMVCContext context)
        {
            _context = context;
        }

        // GET: ExpenseTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseTag.ToListAsync());
        }

        // GET: ExpenseTags/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTag = await _context.ExpenseTag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseTag == null)
            {
                return NotFound();
            }

            return View(expenseTag);
        }

        // GET: ExpenseTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ExpenseTag expenseTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseTag);
        }

        // GET: ExpenseTags/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTag = await _context.ExpenseTag.SingleOrDefaultAsync(m => m.Id == id);
            if (expenseTag == null)
            {
                return NotFound();
            }
            return View(expenseTag);
        }

        // POST: ExpenseTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] ExpenseTag expenseTag)
        {
            if (id != expenseTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTagExists(expenseTag.Id))
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
            return View(expenseTag);
        }

        // GET: ExpenseTags/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTag = await _context.ExpenseTag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseTag == null)
            {
                return NotFound();
            }

            return View(expenseTag);
        }

        // POST: ExpenseTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var expenseTag = await _context.ExpenseTag.SingleOrDefaultAsync(m => m.Id == id);
            _context.ExpenseTag.Remove(expenseTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseTagExists(long id)
        {
            return _context.ExpenseTag.Any(e => e.Id == id);
        }
    }
}
