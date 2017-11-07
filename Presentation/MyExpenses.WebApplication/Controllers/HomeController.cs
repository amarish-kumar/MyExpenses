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
        public HomeController(IExpensesAppService expensesAppService)
        {
            var allExpenses = expensesAppService.GetAllExpenses();
            allExpenses.ForEach(Console.WriteLine);
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
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}