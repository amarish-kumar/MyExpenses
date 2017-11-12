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

    public class TagsController : Controller
    {
        private readonly ITagsAppService _tagsAppService;

        public TagsController(ITagsAppService tagsAppService)
        {
            _tagsAppService = tagsAppService;
        }

        // GET: Tags
        public ActionResult Index()
        {
            var tags = _tagsAppService.GetAllTags();
            return View(tags);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Tags/Create")]
        public ActionResult Create([Bind(Include = "")]TagDto tagDto)
        {
            if (ModelState.IsValid)
            {
                MyResults result = _tagsAppService.SaveOrUpdateTag(tagDto);
                if(result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Tags/Create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}