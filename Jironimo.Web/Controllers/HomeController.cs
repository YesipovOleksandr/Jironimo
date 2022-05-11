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
        private readonly ICategoryService _categoryService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IApplicationService applicationService, IMapper mapper, ICategoryService categoryService)
        {
            _logger = logger;
            _mapper = mapper;
            _applicationService = applicationService;
            _categoryService = categoryService;
        }

        public IActionResult MainPage()
        {
            var applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());
            return View(applications);
        }

        public IActionResult Work()
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());
            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}