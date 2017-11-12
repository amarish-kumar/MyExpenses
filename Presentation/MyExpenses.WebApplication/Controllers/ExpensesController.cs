/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Controllers
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Util.Results;
    using System.Web.Mvc;

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
            var allExpenses = _expensesAppService.GetAllExpenses();

            return View(allExpenses);
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
        public ActionResult Create([Bind(Include = "")]ExpenseDto expenseDto)
        {
            if (ModelState.IsValid)
            {
                MyResults result = _expensesAppService.SaveOrUpdateExpense(expenseDto);
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}