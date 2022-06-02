using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;
using Jironimo.Web.Areas.Admin.Models.ApplicationDetails;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class ApplicationDetailsController : Controller
    {
        private readonly IApplicationDetailsService _applicationDetailsService;
        private readonly IApplicationService _applicationService;
        private readonly IImageUploadService _imageUploadService;
        private readonly IMapper _mapper;

        public ApplicationDetailsController(IApplicationDetailsService applicationDetailsService,
                                            IMapper mapper,
                                            IApplicationService applicationService,
                                            IImageUploadService imageUploadService)
        {
            _applicationDetailsService = applicationDetailsService;
            _applicationService = applicationService;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        public ActionResult Index()
        {
            ViewBag.Applications = _applicationService.GetAplicationsWithDetails();
            return View("~/Areas/Admin/Views/ApplicationDetails/ApplicationDetails.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationDetailsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newApplicationDetails = _mapper.Map<ApplicationDetails>(model);
                newApplicationDetails.ImagePath = await _imageUploadService.UploadImage(model.ImagePath, "/images/ApplicationDetails/");
                if (model.ImagePathTwo != null) { newApplicationDetails.ImagePathTwo = await _imageUploadService.UploadImage(model.ImagePathTwo, "/images/ApplicationDetails/"); }
                try
                {
                    _applicationDetailsService.Create(newApplicationDetails);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Applications = _applicationService.GetAplicationsWithDetails();
            return View("~/Areas/Admin/Views/ApplicationDetails/ApplicationDetails.cshtml", model);
        }

        public ActionResult Delete(Guid id)
        {
            var applicationDetails = _applicationDetailsService.GetById(id);
            _imageUploadService.DeleteImage(applicationDetails.ImagePath, "/images/ApplicationDetails/");
            if (applicationDetails.ImagePathTwo != null) { _imageUploadService.DeleteImage(applicationDetails.ImagePathTwo, "/images/ApplicationDetails/"); }
            _applicationDetailsService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
