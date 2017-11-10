/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Controllers
{
    using MyExpenses.Application.Interfaces;
    
    using System.Web.Mvc;

    public class ExpensesController : Controller
    {
        private readonly IExpensesAppService _expensesAppService;

        public ExpensesController(IExpensesAppService expensesAppService)
        {
            _expensesAppService = expensesAppService;
        }

        // GET: Expenses
        [Route("Expenses")]
        public ActionResult Index()
        {
            var allExpenses = _expensesAppService.GetAllExpenses();

            return View(allExpenses);
        }

        // GET: Expenses
        [Route("Expenses/Create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}