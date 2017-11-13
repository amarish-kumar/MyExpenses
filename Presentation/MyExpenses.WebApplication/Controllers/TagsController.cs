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

    [RoutePrefix("Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsAppService<TagDto> _tagsAppService;

        public TagsController(ITagsAppService<TagDto> tagsAppService)
        {
            _tagsAppService = tagsAppService;
        }

        [Route]
        public ActionResult Index()
        {
            ICollection<TagDto> tags = _tagsAppService.GetAll();
            return View(tags.Select(TagModel.ToModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "")]TagModel model)
        {
            if (ModelState.IsValid)
            {
                MyResults result = _tagsAppService.SaveOrUpdate(TagModel.ToDto(model));
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
            var dto = _tagsAppService.GetById(id);
            return View(TagModel.ToModel(dto));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(TagModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _tagsAppService.SaveOrUpdate(TagModel.ToDto(model));
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}