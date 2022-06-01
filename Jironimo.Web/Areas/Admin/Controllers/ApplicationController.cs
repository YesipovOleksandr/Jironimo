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
        private readonly IDeveloperService _developerService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        private readonly IImageUploadService _imageUploadService;

        public ApplicationController(ICategoryService categoryService,
                                     IApplicationService applicationService,
                                     IMapper mapper,
                                     IDeveloperService developerService,
                                     IImageUploadService imageUploadService)
        {
            _applicationService = applicationService;
            _categoryService = categoryService;
            _developerService = developerService;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        public ActionResult Index()
        {
            ApplicationCRUDViewModel applicationCRUDViewModel = new ApplicationCRUDViewModel();
            applicationCRUDViewModel.ApplicationCreate = new ApplicationCreateViewModel();
            applicationCRUDViewModel.ApplicationCreate.Developers = _mapper.Map<List<DeveloperListSelect>>(_developerService.GetDevelopers());
            applicationCRUDViewModel.Categories =_mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());      
            applicationCRUDViewModel.ApplicationViews = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());

            return View("~/Areas/Admin/Views/Application/Application.cshtml", applicationCRUDViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationCRUDViewModel model)
        {
            var developersIds = new List<Guid>();
            var newApplication = _mapper.Map<Application>(model.ApplicationCreate);
            if (model.ApplicationCreate.Developers != null)
            {
                developersIds = model.ApplicationCreate.Developers.Where(x => x.Selected == true).Select(y => y.Id).ToList();
            }
            newApplication.ImagePath = await _imageUploadService.UploadImage(model.ApplicationCreate.ImagePath, "/images/Applications/");

            try
            {
                _applicationService.Create(newApplication, developersIds);
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
