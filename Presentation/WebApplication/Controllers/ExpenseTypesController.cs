using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyExpenses.Domain.Models;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class ExpenseTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseType.ToListAsync());
        }

        // GET: ExpenseTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseType = await _context.ExpenseType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseType == null)
            {
                return NotFound();
            }

            return View(expenseType);
        }

        // GET: ExpenseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseType);
        }

        // GET: ExpenseTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseType = await _context.ExpenseType.SingleOrDefaultAsync(m => m.Id == id);
            if (expenseType == null)
            {
                return NotFound();
            }
            return View(expenseType);
        }

        // POST: ExpenseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Id")] ExpenseType expenseType)
        {
            if (id != expenseType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTypeExists(expenseType.Id))
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
            return View(expenseType);
        }

        // GET: ExpenseTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseType = await _context.ExpenseType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (expenseType == null)
            {
                return NotFound();
            }

            return View(expenseType);
        }

        // POST: ExpenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var expenseType = await _context.ExpenseType.SingleOrDefaultAsync(m => m.Id == id);
            _context.ExpenseType.Remove(expenseType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseTypeExists(long id)
        {
            return _context.ExpenseType.Any(e => e.Id == id);
        }
    }
}
