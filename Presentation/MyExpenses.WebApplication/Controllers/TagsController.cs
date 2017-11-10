/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Controllers
{
    using MyExpenses.Application.DataTransferObject;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class TagsController : Controller
    {
        // GET: Tags
        public ActionResult Index()
        {
            return View(new List<TagDto>());
        }

        
        public ActionResult Create()
        {
            return View();
        }
    }
}