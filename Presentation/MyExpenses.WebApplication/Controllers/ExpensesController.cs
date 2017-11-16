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
    using MyExpenses.WebApplication.ViewModels;

    [RoutePrefix("Expenses")]
    public class ExpensesController : Controller
    {
        private readonly IExpensesAppService _appService;
        private readonly ITagsAppService _tagsAppService;

        public ExpensesController(
            IExpensesAppService expensesAppService,
            ITagsAppService tagsAppService)
        {
            _appService = expensesAppService;
            _tagsAppService = tagsAppService;
        }

        [Route]
        public ActionResult Index()
        {
            ICollection<ExpenseDto> allExpenses = _appService.GetAll();
            return View(allExpenses.Select(ExpenseModel.ToModel));
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            ExpensesViewModel viewModel = new ExpensesViewModel();

            var all = _tagsAppService.GetAll();

            viewModel.SelectedTag = all.Any() ? all.First().Id : 0;
            viewModel.AllTags = new SelectList(all, "Id", "Name", viewModel.SelectedTag);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "")]ExpensesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var expenseDto = ExpenseModel.ToDto(viewModel.Model);

                if (viewModel.SelectedTag > 0)
                {
                    var tag = _tagsAppService.GetById(viewModel.SelectedTag);
                    expenseDto.Tags = new List<TagDto> { tag };
                }
                else
                {
                    expenseDto.Tags.Clear();
                }

                MyResults result = _appService.AddOrUpdate(expenseDto);
                if (result.Type == MyResultsType.Ok)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(long id)
        {
            ExpensesViewModel viewModel = new ExpensesViewModel();
            viewModel.Model = ExpenseModel.ToModel(_appService.GetById(id));
            var all = _tagsAppService.GetAll();
            if (all.Any())
            {
                if (viewModel.Model.Tags.Any())
                {
                    viewModel.SelectedTag = viewModel.Model.Tags.FirstOrDefault().Id;
                }
                else
                {
                    viewModel.SelectedTag = 0;
                }

                viewModel.AllTags = new SelectList(all, "Id", "Name", viewModel.SelectedTag);
            }

            return View(viewModel);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(ExpensesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = _tagsAppService.GetById(viewModel.SelectedTag);
                var expenseDto = ExpenseModel.ToDto(viewModel.Model);
                expenseDto.Tags = new List<TagDto> { tag };

                var result = _appService.AddOrUpdate(expenseDto);
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
            return View(ExpenseModel.ToModel(dto));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(ExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _appService.Remove(ExpenseModel.ToDto(model));
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
            return View(ExpenseModel.ToModel(dto));
        }
    }
}