/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Controllers
{
    using System.Linq;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Util.Results;
    using System.Web.Mvc;

    using MyExpenses.WebApplication.Models;

    [RoutePrefix("Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsAppService _tagsAppService;

        public TagsController(ITagsAppService tagsAppService)
        {
            _tagsAppService = tagsAppService;
        }

        [Route]
        public ActionResult Index()
        {
            var tags = _tagsAppService.GetAllTags();
            return View(tags.Select(TagModel.ToModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "")]TagModel model)
        {
            if (ModelState.IsValid)
            {
                MyResults result = _tagsAppService.SaveOrUpdateTag(TagModel.ToDto(model));
                if(result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}