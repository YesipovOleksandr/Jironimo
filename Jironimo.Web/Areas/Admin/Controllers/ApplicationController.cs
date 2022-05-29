using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;
using Jironimo.Web.Areas.Admin.Models.Application;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        private readonly IImageUploadService _imageUploadService;

        public ApplicationController(ICategoryService categoryService,
                                     IApplicationService applicationService,
                                     IMapper mapper,
                                     IImageUploadService imageUploadService)
        {
            _applicationService = applicationService;
            _categoryService = categoryService;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        public ActionResult Index()
        {
            ApplicationCRUDViewModel applicationCRUDViewModel = new ApplicationCRUDViewModel();
            applicationCRUDViewModel.Categories =_mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());      
            applicationCRUDViewModel.ApplicationViews = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());

            return View("~/Areas/Admin/Views/Application/Application.cshtml", applicationCRUDViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationCRUDViewModel model)
        {
            var newApplication = _mapper.Map<Application>(model.ApplicationCreate);
            newApplication.ImagePath = await _imageUploadService.UploadImage(model.ApplicationCreate.ImagePath, "/images/Applications/");
      
            try
            {
                _applicationService.Create(newApplication);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

       public ActionResult Delete(Guid id)
        {
            var application = _applicationService.GetById(id);
            _imageUploadService.DeleteImage(application.ImagePath, "/images/Applications/");
            _applicationService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
