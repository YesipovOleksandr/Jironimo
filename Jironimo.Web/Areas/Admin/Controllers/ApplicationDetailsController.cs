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
            ApplicationDetailsCRUDViewModel applicationDetails = new ApplicationDetailsCRUDViewModel();
            applicationDetails.Applications = _applicationService.GetById();
            return View("~/Areas/Admin/Views/ApplicationDetails/ApplicationDetails.cshtml", applicationDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationDetailsCRUDViewModel model)
        {
            var newApplicationDetails = _mapper.Map<ApplicationDetails>(model.ApplicationDetailsCreate);
            newApplicationDetails.ImagePath = await _imageUploadService.UploadImage(model.ApplicationDetailsCreate.ImagePath, "/images/ApplicationDetails/");
            if (model.ApplicationDetailsCreate.ImagePathTwo != null) { newApplicationDetails.ImagePathTwo = await _imageUploadService.UploadImage(model.ApplicationDetailsCreate.ImagePathTwo, "/images/ApplicationDetails/"); }
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
