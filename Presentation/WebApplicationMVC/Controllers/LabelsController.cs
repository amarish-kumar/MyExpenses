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

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.WebApplicationMVC.Models;
    using MyExpenses.WebApplicationMVC.Properties;

    public class LabelsController : Controller
    {
        private readonly ILabelAppService _appService;
        private readonly IExpenseAppService _expenseAppService;

        public LabelsController(ILabelAppService labelAppService, IExpenseAppService expenseAppService)
        {
            _appService = labelAppService;
            _expenseAppService = expenseAppService;
        }

        // GET: Labels
        public IActionResult Index(int month, int year)
        {
            DateTime startDateTime = Util.MyDate.GetStartDateTime(month, year);
            DateTime endDateTime = Util.MyDate.GetEndDateTime(month, year);

            LabelIndexViewModel viewModel = new LabelIndexViewModel
            {
                Labels = _appService.Get(startDateTime, endDateTime).ToList(),
                Month = startDateTime.Month,
                Year = startDateTime.Year
            };

            CreateDateLists(viewModel.Month, viewModel.Year);

            return View(viewModel);
        }

        // GET: Labels/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = _appService.GetById(id.Value);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // GET: Labels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id")] LabelDto label)
        {
            if (ModelState.IsValid)
            {
                _appService.Add(label);
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: Labels/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = _appService.GetById(id.Value);
            if (label == null)
            {
                return NotFound();
            }
            return View(label);
        }

        // POST: Labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Name,Id")] LabelDto label)
        {
            if (id != label.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appService.Update(label);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelExists(label.Id))
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
            return View(label);
        }

        // GET: Labels/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = _appService.GetById(id.Value);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // POST: Labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _appService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LabelExists(long id)
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
