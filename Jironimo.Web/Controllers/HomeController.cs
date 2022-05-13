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
        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Work()
        {
            CategoryApplicationViewModel categoryApplication = new CategoryApplicationViewModel();
            categoryApplication.Categories = new List<CategoryViewModel>();
            categoryApplication.Categories.Add(new CategoryViewModel { Name = "All", IsActive = false });
            categoryApplication.Categories.AddRange(_mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories()));

            if (Request.Query.TryGetValue("categoryId", out var categoryId))
            {
                if (categoryId != "")
                {
                    categoryApplication.Applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplicationsByCategoryId(new Guid(categoryId)));
                    categoryApplication.Categories = categoryApplication.Categories.Select(p => p.Id == new Guid(categoryId)
                      ? new CategoryViewModel { Name = p.Name, IsActive = true } : p).ToList();
                    return View(categoryApplication);
                }
            }
            categoryApplication.Applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());
            categoryApplication.Categories[0].IsActive = true;

            return View(categoryApplication);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}