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
            ViewBag.Developers= _developerService.GetDevelopers();
            return View("~/Areas/Admin/Views/Developer/Developer.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeveloperCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newDeveloper = _mapper.Map<Developer>(model);
                newDeveloper.ImagePath = await _imageUploadService.UploadImage(model.ImagePath, "/images/Developers/");

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
            ViewBag.Developers = _developerService.GetDevelopers();
            return View("~/Areas/Admin/Views/Developer/Developer.cshtml", model);
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
