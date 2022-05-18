using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Web.Areas.Admin.Models;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ApplicationController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            ApplicationCRUDViewModel applicationCRUDViewModel = new ApplicationCRUDViewModel();
            applicationCRUDViewModel.Categories =_mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());
            return View("~/Areas/Admin/Views/Application/Application.cshtml", applicationCRUDViewModel);
        }

        // GET: ApplicationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
