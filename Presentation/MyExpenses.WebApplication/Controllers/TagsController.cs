/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Util.Results;
    using System.Web.Mvc;

    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.WebApplication.Models;

    [RoutePrefix("Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsAppService _appService;

        public TagsController(ITagsAppService appService)
        {
            _appService = appService;
        }

        [Route]
        public ActionResult Index()
        {
            ICollection<TagDto> tags = _appService.GetAll();
            return View(tags.Select(TagModel.ToModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "")]TagModel model)
        {
            if (ModelState.IsValid)
            {
                MyResults result = _appService.AddOrUpdate(TagModel.ToDto(model));
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

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(long id)
        {
            var dto = _appService.GetById(id);
            return View(TagModel.ToModel(dto));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(TagModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _appService.AddOrUpdate(TagModel.ToDto(model));
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
            return View(TagModel.ToModel(dto));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(TagModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _appService.Remove(TagModel.ToDto(model));
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
            return View(TagModel.ToModel(dto));
        }
    }
}