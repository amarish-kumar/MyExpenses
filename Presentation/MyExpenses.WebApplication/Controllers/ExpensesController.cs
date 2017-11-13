/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Util.Results;
    using System.Web.Mvc;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.WebApplication.Models;

    [RoutePrefix("Expenses")]
    public class ExpensesController : Controller
    {
        private readonly IExpensesAppService<ExpenseDto> _appService;

        public ExpensesController(IExpensesAppService<ExpenseDto> expensesAppService)
        {
            _appService = expensesAppService;
        }

        [Route]
        public ActionResult Index()
        {
            ICollection<ExpenseDto> allExpenses = _appService.GetAll();
            return View(allExpenses.Select(ExpenseModel.ToModel));
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "")]ExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                MyResults result = _appService.SaveOrUpdate(ExpenseModel.ToDto(model));
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(long id)
        {
            var dto = _appService.GetById(id);
            return View(ExpenseModel.ToModel(dto));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(ExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _appService.SaveOrUpdate(ExpenseModel.ToDto(model));
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(long id)
        {
            var dto = _appService.GetById(id);
            return View(ExpenseModel.ToModel(dto));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(ExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _appService.Remove(ExpenseModel.ToDto(model));
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(long id)
        {
            var dto = _appService.GetById(id);
            return View(ExpenseModel.ToModel(dto));
        }
    }
}