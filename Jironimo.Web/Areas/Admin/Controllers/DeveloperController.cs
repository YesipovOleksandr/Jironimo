using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Developers;
using Jironimo.Web.Areas.Admin.Models.Developers;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;
        private readonly IImageUploadService _imageUploadService;
        private readonly IMapper _mapper;

        public DeveloperController(IDeveloperService developerService, IMapper mapper, IImageUploadService imageUploadService)
        {
            _developerService = developerService;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        public ActionResult Index()
        {
            DeveloperCRUDViewModel developerCRUDViewModel = new DeveloperCRUDViewModel();
            developerCRUDViewModel.Developers = _developerService.GetDevelopers();

            return View("~/Areas/Admin/Views/Developer/Developer.cshtml", developerCRUDViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeveloperCRUDViewModel model)
        {
            var newDeveloper = _mapper.Map<Developer>(model.DeveloperCreate);

            newDeveloper.ImagePath = await _imageUploadService.UploadImage(model.DeveloperCreate.ImagePath, "/images/Developers/");

            try
            {
                var application = _mapper.Map<Developer>(newDeveloper);
                _developerService.Create(application);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Delete(Guid id)
        {
            var applicationDetails = _developerService.GetById(id);
            _imageUploadService.DeleteImage(applicationDetails.ImagePath, "/images/Developers/");
            _developerService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
