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
        private readonly IApplicationDetaisService _applicationDetaisService;
        private readonly IMapper _mapper;
        private readonly List<TypeMarketViewModel> _typeMarketListViewModel = new List<TypeMarketViewModel>() { new TypeMarketViewModel { Name = "All", Value = "" }, new TypeMarketViewModel { Name = "Outsourse", Value = "true" }, new TypeMarketViewModel { Name = "Our products", Value = "false" } };
        public HomeController(ILogger<HomeController> logger,
            IApplicationService applicationService,
            IMapper mapper,
            ICategoryService categoryService,
            IApplicationDetaisService applicationDetaisService)
        {
            _logger = logger;
            _mapper = mapper;
            _applicationService = applicationService;
            _categoryService = categoryService;
            _applicationDetaisService = applicationDetaisService;
        }

        public IActionResult MainPage()
        {
            var applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());
            return View(applications);
        }
        public IActionResult Service()
        {
            var applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());
            return View(applications);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet("applicationDetails/{id:Guid}")]
        public IActionResult ApplicationDetails(Guid id)
        {
            var applicationsDetails = _mapper.Map<List<ApplicationDetailsViewModel>>(_applicationDetaisService.GetAplicationsDetailsById(id));
            return View(applicationsDetails);
        }
        
        public IActionResult Work()
        {
            CategoryApplicationViewModel categoryApplication = new CategoryApplicationViewModel();
            categoryApplication.Categories = new List<CategoryViewModel>();
            categoryApplication.Categories.Add(new CategoryViewModel { Name = "All", IsActive = false });
            categoryApplication.Categories.AddRange(_mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories()));
            categoryApplication.TypeMarkets = _typeMarketListViewModel;

            if (Request.Query.TryGetValue("outSource", out var _outSource) && Request.Query.TryGetValue("categoryId", out var _categoryId))
            {
                if (_outSource != "" && _categoryId != "")
                {
                    categoryApplication.TypeMarkets = categoryApplication.TypeMarkets.Select(x => x.Value == _outSource.ToString() ? new TypeMarketViewModel { Name = x.Name, Value = x.Value, IsActive = true } : x).ToList();
                    categoryApplication.Applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplicationsByCategoryId(new Guid(_categoryId)).Where(x => x.OutSource == bool.Parse(_outSource)));
                    categoryApplication.Categories = categoryApplication.Categories.Select(p => p.Id == new Guid(_categoryId)
                      ? new CategoryViewModel { Name = p.Name, IsActive = true } : p).ToList();
                    return View(categoryApplication);
                }
            }

            if (Request.Query.TryGetValue("outSource", out var outSource))
            {
                if (outSource != "")
                {
                    categoryApplication.TypeMarkets = categoryApplication.TypeMarkets.Select(x => x.Value == outSource.ToString() ? new TypeMarketViewModel { Name = x.Name, Value = x.Value, IsActive = true } : x).ToList();
                    categoryApplication.Applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications()).Where(x => x.Outsource == bool.Parse(outSource)).ToList();
                    categoryApplication.Categories[0].IsActive = true;

                    return View(categoryApplication);
                }
            }

            if (Request.Query.TryGetValue("categoryId", out var categoryId))
            {
                if (categoryId != "")
                {
                    categoryApplication.Applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplicationsByCategoryId(new Guid(categoryId)));
                    categoryApplication.Categories = categoryApplication.Categories.Select(p => p.Id == new Guid(categoryId)
                      ? new CategoryViewModel { Name = p.Name, IsActive = true } : p).ToList();

                    categoryApplication.TypeMarkets[0].IsActive = true;

                    return View(categoryApplication);
                }
            }
            categoryApplication.Applications = _mapper.Map<List<ApplicationViewModel>>(_applicationService.GetAplications());
            categoryApplication.Categories[0].IsActive = true;
            categoryApplication.TypeMarkets[0].IsActive = true;

            return View(categoryApplication);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}