using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Web.Models;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jironimo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IApplicationService applicationService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _applicationService = applicationService;
        }

        public IActionResult MainPage()
        {
            var applications = _mapper.Map <List<ApplicationViewModel>>(_applicationService.GetAplications());

            return View(applications);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}