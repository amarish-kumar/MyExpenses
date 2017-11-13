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
        private readonly IExpensesAppService _expensesAppService;

        public ExpensesController(IExpensesAppService expensesAppService)
        {
            _expensesAppService = expensesAppService;
        }

        [Route]
        public ActionResult Index()
        {
            List<ExpenseDto> allExpenses = _expensesAppService.GetAllExpenses();
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
                MyResults result = _expensesAppService.SaveOrUpdateExpense(ExpenseModel.ToDto(model));
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}