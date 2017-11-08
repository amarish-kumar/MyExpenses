using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyExpenses.WebApplication.Controllers
{
    using MyExpenses.Application.Interfaces;

    public class HomeController : Controller
    {
        private readonly IExpensesAppService _expensesAppService;

        public HomeController(IExpensesAppService expensesAppService)
        {
            _expensesAppService = expensesAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            string text = String.Empty;

            var allExpenses = _expensesAppService.GetAllExpenses();
            allExpenses.ForEach(x => text += " " + x.Name);

            ViewBag.Message = text;

            return View();
        }
    }
}