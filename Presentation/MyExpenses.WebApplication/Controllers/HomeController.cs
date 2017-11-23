/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Presentaion.WebApplication.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [Route]
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

            ViewBag.Message = text;

            return View();
        }
    }
}