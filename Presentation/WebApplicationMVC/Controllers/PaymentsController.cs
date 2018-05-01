/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Context;

    public class PaymentsController : Controller
    {
        private readonly MyExpensesContext _context;

        public PaymentsController(MyExpensesContext context)
        {
            _context = context;
        }

        // GET: Hows
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payment.ToListAsync());
        }

        // GET: Hows/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var how = await _context.Payment
                .SingleOrDefaultAsync(m => m.Id == id);
            if (how == null)
            {
                return NotFound();
            }

            return View(how);
        }

        // GET: Hows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: Hows/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var how = await _context.Payment.SingleOrDefaultAsync(m => m.Id == id);
            if (how == null)
            {
                return NotFound();
            }
            return View(how);
        }

        // POST: Hows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Id")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HowExists(payment.Id))
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

        // GET: Hows/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var how = await _context.Payment
                .SingleOrDefaultAsync(m => m.Id == id);
            if (how == null)
            {
                return NotFound();
            }

            return View(how);
        }

        // POST: Hows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var how = await _context.Payment.SingleOrDefaultAsync(m => m.Id == id);
            _context.Payment.Remove(how);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HowExists(long id)
        {
            return _context.Payment.Any(e => e.Id == id);
        }
    }
}
