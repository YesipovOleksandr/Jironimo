using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;
using Jironimo.Web.Areas.Admin.Models;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(ICategoryService categoryService, IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            ApplicationCRUDViewModel applicationCRUDViewModel = new ApplicationCRUDViewModel();
            applicationCRUDViewModel.Categories =_mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());
            return View("~/Areas/Admin/Views/Application/Application.cshtml", applicationCRUDViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationCRUDViewModel model)
        {
            try
            {
                var application = _mapper.Map<Application>(model.ApplicationCreate);
                _applicationService.Create(application);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
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
